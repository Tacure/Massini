
using Massini.Bindings.Vma;
using Massini.Bindings.Vma.Enums;
using Massini.Bindings.Vma.Handles;
using Massini.Bindings.Vma.Structs;
using Massini.Bindings.Vulkan;
using Massini.Core;
using Massini.Core.Math.Primitives;
using Massini.Flamet2.Api.Level1.Classes;
using Massini.Flamet2.Api.Level1.Interfaces;
using Massini.Flamet2.Api.Level1.Structs;

namespace Massini.Flamet2.Impl.Classes
{
    internal sealed unsafe class Texture : ITexture1
    {
        public Texture(Lane i_lane, TextureCreateParams i_createParams)
        {
            Device device = (Device)i_lane.GetInfo().Device;
            
            // TODO: Check why we imposed this limitation.
            if (i_createParams.p_mipLevelCount > 64)
            {
                throw new ArgumentException("i_mipLevelCount should be less or equal than 64.");
            }

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

            uint familyIndex = i_lane.FamilyIndex;
            VkImage_T* image = null;
            VmaAllocation* allocation = null;
            VmaAllocationInfo allocationInfo = new();
            VkImageCreateInfo imageCreateInfo = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_IMAGE_CREATE_INFO,
                pNext = null,
                flags = 0,
                samples = sampleCount,
                sharingMode = VkSharingMode.VK_SHARING_MODE_EXCLUSIVE,
                queueFamilyIndexCount = 1,
                pQueueFamilyIndices = &familyIndex,
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
            VkResult result = Vma.vmaCreateImage(device.VmaAllocatorPtr, &imageCreateInfo, &allocationCreateInfo, &image, &allocation, &allocationInfo);
            if (result != VkResult.VK_SUCCESS)
            {
                throw new Exception("Failed to create texture");
            }
            
            m_lane = i_lane;
            m_isDisposed = false;
            m_isWrapper = false;
            m_ptr_image = image;
            m_ptr_allocation = allocation;
            m_layerBarriers = new TextureBarrierState(arrayLayers, mipLevelCount);

            m_textureInfo = new TextureInfo()
            {
                Id = Rid.NewId(),
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
                    Device device = (Device)m_lane.GetInfo().Device;
                    
                    // TODO: Check if VMA is thread safe, if not, create a wrapper class with locks.
                    Vma.vmaDestroyImage(device.VmaAllocatorPtr, m_ptr_image, m_ptr_allocation);
                }
            }
        }

        public TextureInfo GetInfo()
        {
            return m_textureInfo;
        }

        public ILane1 GetLane()
        {
            return m_lane;
        }

        public void SetLabel(string i_label)
        {
            if (m_isDisposed) return;
            
            Device device = (Device)m_lane.GetInfo().Device;
            IntSharedFuncs.SetObjectLabel(device, m_ptr_image, VkObjectType.VK_OBJECT_TYPE_IMAGE, i_label);        
        }
        
        public ITextureView1 CreateTextureView(in TextureViewCreateParams i_createParams)
        {
            return new TextureView(this, in i_createParams);
        }

        internal VkImage_T* VkImagePtr => m_ptr_image;
        
        internal static Texture CreateWrapper(
            Lane i_lane,
            VkImage_T* i_ptr_image,
            VkExtent3D i_extent,
            VkFormat i_format,
            VkImageType i_imageType,
            uint i_mipLevelCount,
            VkSampleCountFlagBits i_sampleCount,
            bool i_isSwapchainTexture)
        {
            // TODO: Check why we imposed this limitation.
            if (i_mipLevelCount > 64)
            {
                throw new ArgumentException("i_mipLevelCount should be less or equal than 64.");
            }

            return new Texture(
                i_lane,
                true,
                i_isSwapchainTexture,
                i_mipLevelCount,
                i_sampleCount,
                i_extent,
                i_format,
                i_imageType,
                i_ptr_image,
                null);
        }

        private bool m_isDisposed = false;
        private readonly Lane m_lane;
        private readonly TextureInfo m_textureInfo;
        private readonly bool m_isWrapper;
        private readonly bool m_isSwapchainTexture;
        private readonly VkImage_T* m_ptr_image;
        private readonly VmaAllocation* m_ptr_allocation;
        private readonly TextureBarrierState m_layerBarriers;
        
        private Texture(
            Lane i_lane,
            bool i_isWrapper,
            bool i_isSwapchainTexture,
            uint i_mipLevelCount,
            VkSampleCountFlagBits i_sampleCount,
            VkExtent3D i_extent,
            VkFormat i_format,
            VkImageType i_imageType,
            VkImage_T* i_ptr_image,
            VmaAllocation* i_ptr_allocation)
        {
            m_lane = i_lane;
            m_isWrapper = i_isWrapper;
            m_isSwapchainTexture = i_isSwapchainTexture;
            m_ptr_image = i_ptr_image;
            m_ptr_allocation = i_ptr_allocation;
            m_layerBarriers = new TextureBarrierState(ONE, i_mipLevelCount);
            
            m_textureInfo = new TextureInfo()
            {
                Id = Rid.NewId(),
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