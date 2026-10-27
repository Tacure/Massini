
using Massini.Bindings.Vma;
using Massini.Bindings.Vma.Enums;
using Massini.Bindings.Vma.Handles;
using Massini.Bindings.Vma.Structs;
using Massini.Bindings.Vulkan;
using Massini.Core;
using Massini.Core.Math.Primitives;
using Massini.Flamet2.Api.Level1.Classes;
using Massini.Flamet2.Api.Level1.Enums;
using Massini.Flamet2.Api.Level1.Interfaces;
using Massini.Flamet2.Api.Level1.Structs;

namespace Massini.Flamet2.Impl.Classes
{
    internal sealed unsafe class Texture : ITexture1
    {
        public Texture(Device i_device, in TextureCreateParams i_createParams)
        {
            if (i_createParams.p_mipLevelCount > MAX_MIP_LEVELS)
            {
                throw new ArgumentException($"i_mipLevelCount should be less or equal than {MAX_MIP_LEVELS}.");
            }

            Lane lane = (Lane)i_createParams.p_initialLane;
            uint queueFamilyCount = ONE;
            VkSharingMode sharingMode = VkSharingMode.VK_SHARING_MODE_EXCLUSIVE;
            uint queueFamilyIdx = lane.FamilyIndex;

            VkExtent3D extent = new()
            {
                width = i_createParams.p_size.Width,
                height = i_createParams.p_size.Height,
                depth = i_createParams.p_size.Depth,
            };
            VkImageType imageType = IntSharedCvs.TextureTypeToVkImageType(i_createParams.p_type);
            VkFormat format = IntSharedCvs.TextureFormatToVkFormat(i_createParams.p_format);
            VkSampleCountFlagBits sampleCount = IntSharedCvs.SampleCountToVkSampleCountFlagBits(i_createParams.p_sampleCount);
            uint mipLevelCount = i_createParams.p_mipLevelCount;
            uint arrayLayers = i_createParams.p_arrayLayers;

            VkImage_T* image = null;
            VmaAllocation* allocation = null;
            VmaAllocationInfo allocationInfo = new();
            VkImageCreateInfo imageCreateInfo = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_IMAGE_CREATE_INFO,
                pNext = null,
                flags = 0,
                samples = sampleCount,
                sharingMode = sharingMode,
                queueFamilyIndexCount = queueFamilyCount,
                pQueueFamilyIndices = &queueFamilyIdx,
                extent = extent,
                format = format,
                imageType = imageType,
                initialLayout = VkImageLayout.VK_IMAGE_LAYOUT_UNDEFINED,
                mipLevels = mipLevelCount,
                arrayLayers = arrayLayers,
                usage = (uint)IntSharedCvs.TextureUsageFlagsToVkImageUsageFlagBits(i_createParams.p_usage),
                tiling = VkImageTiling.VK_IMAGE_TILING_OPTIMAL,
            };

            VmaAllocationCreateInfo allocationCreateInfo = new()
            {
                p_usage = VmaMemoryUsage.VMA_MEMORY_USAGE_AUTO,
            };

            // TODO: Check if VMA is thread safe, if not, create a wrapper class with locks.
            VkResult result = Vma.vmaCreateImage(i_device.VmaAllocatorPtr, &imageCreateInfo, &allocationCreateInfo, &image, &allocation, &allocationInfo);
            if (result != VkResult.VK_SUCCESS)
            {
                throw new Exception("Failed to create texture");
            }
            
            m_isDisposed = false;
            m_isWrapper = false;
            m_ptr_image = image;
            m_ptr_allocation = allocation;
            m_textureBarrierState = new TextureBarrierState(arrayLayers, mipLevelCount, queueFamilyIdx);

            m_textureInfo = new TextureInfo()
            {
                Id = Rid.NewId(),
                Device = i_device,
                Extent = new Vec3<uint>(extent.width, extent.height, extent.depth),
                Format = IntSharedCvs.VkFormatToTextureFormat(format),
                TextureType = IntSharedCvs.VkImageTypeToTextureType(imageType),
                MipCount = mipLevelCount,
                ArrayLayerCount = arrayLayers,
                SampleCount = IntSharedCvs.VkSampleCountFlagBitsToSampleCount(sampleCount),
            };
        }
        
        /// <inheritdoc/>
        public void Dispose()
        {
            if (!m_isDisposed)
            {
                m_isDisposed = true;
                if (!m_isWrapper)
                {
                    Device device = (Device)m_textureInfo.Device;
                    
                    // TODO: Check if VMA is thread safe, if not, create a wrapper class with locks.
                    Vma.vmaDestroyImage(device.VmaAllocatorPtr, m_ptr_image, m_ptr_allocation);
                }
            }
        }

        public TextureInfo GetInfo()
        {
            return m_textureInfo;
        }

        public void SetLabel(string i_label)
        {
            if (m_isDisposed) return;
            
            Device device = (Device)m_textureInfo.Device;
            IntSharedFuncs.SetObjectLabel(device, m_ptr_image, VkObjectType.VK_OBJECT_TYPE_IMAGE, i_label);        
        }
        
        public ITextureView1 CreateTextureView(in TextureViewCreateParams i_createParams)
        {
            return new TextureView(this, in i_createParams);
        }

        internal VkImage_T* VkImagePtr => m_ptr_image;

        /// <summary>
        /// Creates a new <see cref="Texture"/> instance as a wrapper around a Vulkan image.
        /// </summary>
        /// <param name="i_device">The Vulkan device associated with the texture.</param>
        /// <param name="i_ptr_image">A pointer to the Vulkan image to wrap.</param>
        /// <param name="i_extent">Specifies the dimensions of the texture (width, height, depth).</param>
        /// <param name="i_format">The format of the texture.</param>
        /// <param name="i_imageType">The type of the image (e.g., 1D, 2D, or 3D).</param>
        /// <param name="i_queueFamilyIndex">
        /// The index of the queue family that owns the texture. Use <see cref="uint.MaxValue"/>
        /// if the texture does not have an initial owning family.
        /// </param>
        /// <param name="i_mipLevelCount">The number of mipmap levels the texture has.</param>
        /// <param name="i_sampleCount">The number of samples per pixel for multisampling.</param>
        /// <param name="i_isSwapchainTexture">Indicates whether the texture is part of the swapchain.</param>
        /// <returns>A new instance of <see cref="Texture"/> wrapping the specified Vulkan image.</returns>
        internal static Texture CreateWrapper(
            Device i_device,
            VkImage_T* i_ptr_image,
            VkExtent3D i_extent,
            VkFormat i_format,
            VkImageType i_imageType,
            uint i_queueFamilyIndex,
            uint i_mipLevelCount,
            VkSampleCountFlagBits i_sampleCount,
            bool i_isSwapchainTexture)
        {
            if (i_mipLevelCount > MAX_MIP_LEVELS)
            {
                throw new ArgumentException($"i_mipLevelCount should be less or equal than {MAX_MIP_LEVELS}.");
            }

            return new Texture(
                i_device,
                true,
                i_isSwapchainTexture,
                i_queueFamilyIndex,
                i_mipLevelCount,
                i_sampleCount,
                i_extent,
                i_format,
                i_imageType,
                i_ptr_image,
                null);
        }

        internal TextureBarrierState GetTextureBarrierState()
        {
            return m_textureBarrierState;
        }
        
        private bool m_isDisposed = false;
        private readonly TextureInfo m_textureInfo;
        private readonly bool m_isWrapper;
        private readonly bool m_isSwapchainTexture;
        private readonly VkImage_T* m_ptr_image;
        private readonly VmaAllocation* m_ptr_allocation;
        private readonly TextureBarrierState m_textureBarrierState;
        
        private Texture(
            Device i_device,
            bool i_isWrapper,
            bool i_isSwapchainTexture,
            uint i_queueFamilyIndex,
            uint i_mipLevelCount,
            VkSampleCountFlagBits i_sampleCount,
            VkExtent3D i_extent,
            VkFormat i_format,
            VkImageType i_imageType,
            VkImage_T* i_ptr_image,
            VmaAllocation* i_ptr_allocation)
        {
            m_isWrapper = i_isWrapper;
            m_isSwapchainTexture = i_isSwapchainTexture;
            m_ptr_image = i_ptr_image;
            m_ptr_allocation = i_ptr_allocation;
            m_textureBarrierState = new TextureBarrierState(ONE, i_mipLevelCount, i_queueFamilyIndex);
            
            m_textureInfo = new TextureInfo()
            {
                Id = Rid.NewId(),
                Device = i_device,
                Extent = new Vec3<uint>(i_extent.width, i_extent.height, i_extent.depth),
                Format = IntSharedCvs.VkFormatToTextureFormat(i_format),
                TextureType = IntSharedCvs.VkImageTypeToTextureType(i_imageType),
                MipCount = i_mipLevelCount,
                ArrayLayerCount = ONE,
                SampleCount = IntSharedCvs.VkSampleCountFlagBitsToSampleCount(i_sampleCount),
            };
        }
    }   
}