
using Massini.Bindings.Vma;
using Massini.Bindings.Vma.Enums;
using Massini.Bindings.Vma.Handles;
using Massini.Bindings.Vma.Structs;
using Massini.Bindings.Vulkan;
using Massini.Graphics.VkAL.Classes.Internal;
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Interfaces;
using Massini.Graphics.VkAL.Structs;
using Massini.Graphics.VkAL.Structs.Level1;

namespace Massini.Graphics.VkAL.Classes
{
    public unsafe partial class Texture : IResource, IDisposable
    {
        public TextureFormat Format => VkUtils.VkFormatToTextureFormat(m_format);

        /// <inheritdoc/>
        public ResId Id => m_id;

        /// <inheritdoc/>
        public Device Device => m_device;

        /// <inheritdoc/>
        public bool IsDisposed => m_isDisposed;

        public TextureType Type => VkUtils.VkImageTypeToTextureType(m_imageType);

        public uint MipLevelCount => m_mipLevelCount;

        public uint ArrayLayersCount => m_arrayLayersCount;

        public uint Width => m_extent.width;

        public uint Height => m_extent.height;

        public uint Depth => m_extent.depth;

        public Texture(Device i_device, in TextureCreateParams i_createParams)
        {
            Device device = (Device)i_device;

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
            VkImageType imageType = VkUtils.TextureTypeToVkImageType(i_createParams.p_type);
            VkFormat format = VkUtils.TextureFormatToVkFormat(i_createParams.p_format);
            VkSampleCountFlagBits sampleCount = VkUtils.SampleCountToVkSampleCountFlagBits(i_createParams.p_sampleCount);
            uint mipLevelCount = i_createParams.p_mipLevelCount;
            uint arrayLayers = i_createParams.p_arrayLayers;

            var queueFamilies = device.QueueFamilies;
            uint[] queueFamiliesIndices = new uint[queueFamilies.Count];
            for (int i = 0; i < queueFamiliesIndices.Length; i++)
            {
                queueFamiliesIndices[i] = queueFamilies[i].FamilyIndex;
            }

            VkImage_T* image = null;
            VmaAllocation* allocation = null;
            VmaAllocationInfo allocationInfo = new();
            fixed (uint* queueFamiliesIndicesPtr = queueFamiliesIndices)
            {
                VkImageCreateInfo imageCreateInfo = new()
                {
                    sType = VkStructureType.VK_STRUCTURE_TYPE_IMAGE_CREATE_INFO,
                    pNext = null,
                    flags = 0,
                    samples = sampleCount,
                    sharingMode = VkSharingMode.VK_SHARING_MODE_CONCURRENT,
                    queueFamilyIndexCount = (uint)queueFamiliesIndices.Length,
                    pQueueFamilyIndices = queueFamiliesIndicesPtr,
                    extent = extent,
                    format = format,
                    imageType = imageType,
                    initialLayout = VkImageLayout.VK_IMAGE_LAYOUT_UNDEFINED,
                    mipLevels = mipLevelCount,
                    arrayLayers = arrayLayers,
                    usage = (uint)VkUtils.TextureUsageFlagsToVkImageUsageFlagBits(i_createParams.p_usage),
                    tiling = VkImageTiling.VK_IMAGE_TILING_OPTIMAL,
                };

                VmaAllocationCreateInfo allocationCreateInfo = new()
                {
                    p_usage = VmaMemoryUsage.VMA_MEMORY_USAGE_AUTO,
                };

                VkResult result1 = Vma.vmaCreateImage(device.VmaAllocatorPtr, &imageCreateInfo, &allocationCreateInfo, &image, &allocation, &allocationInfo);
            }

            VkUtils.SetObjectLabel(i_device, image, VkObjectType.VK_OBJECT_TYPE_IMAGE, $"{i_createParams.p_type} - {i_createParams.p_label}");

            m_id = ResId.GetNextId();
            m_label = i_createParams.p_label;
            m_device = device;
            m_isDisposed = false;
            m_isWrapper = false;
            m_ptr_image = image;
            m_ptr_allocation = allocation;
            m_extent = extent;
            m_format = format;
            m_imageType = imageType;
            m_mipLevelCount = mipLevelCount;
            m_arrayLayersCount = arrayLayers;
            m_sampleCount = sampleCount;
            m_layerBarriers = new(arrayLayers, mipLevelCount);
        }

        public void Dispose()
        {
            if (!m_isDisposed)
            {
                m_isDisposed = true;
                GC.SuppressFinalize(this);
                if (!m_isWrapper)
                {
                    Vma.vmaDestroyImage(m_device.VmaAllocatorPtr, m_ptr_image, m_ptr_allocation);
                }
            }
        }

        public TextureView CreateView(in TextureViewCreateParams i_createParams)
        {
            return new TextureView(this, i_createParams);
        }
    }

    public unsafe partial class Texture 
    {
        internal VkImage_T* VkImagePtr => m_ptr_image;

        internal TextureBarrierState LayerBarriers => m_layerBarriers;

        internal VkFormat VkFormat => m_format;

        internal static Texture CreateWrapper(
            Device i_device,
            VkImage_T* i_ptr_image,
            VkExtent3D i_extent,
            VkFormat i_format,
            VkImageType i_imageType,
            uint i_mipLevelCount,
            VkSampleCountFlagBits i_sampleCount)
        {
            if (i_mipLevelCount > 64)
            {
                throw new ArgumentException("i_mipLevelCount should be less or equal than 64.");
            }

            return new Texture(
                nameof(Texture),
                i_device,
                true,
                i_mipLevelCount,
                i_sampleCount,
                i_extent,
                i_format,
                i_imageType,
                i_ptr_image,
                null);
        }

        private bool m_isDisposed = false;
        private readonly string m_label;
        private readonly ResId m_id;
        private readonly Device m_device;
        private readonly bool m_isWrapper;
        private readonly uint m_mipLevelCount;
        private readonly uint m_arrayLayersCount;
        private readonly VkSampleCountFlagBits m_sampleCount;
        private readonly VkExtent3D m_extent;
        private readonly VkFormat m_format;
        private readonly VkImageType m_imageType;
        private readonly VkImage_T* m_ptr_image;
        private readonly VmaAllocation* m_ptr_allocation;

        private readonly TextureBarrierState m_layerBarriers;

        private Texture(
            string i_label,
            Device i_device,
            bool i_isWrapper,
            uint i_mipLevelCount,
            VkSampleCountFlagBits i_sampleCount,
            VkExtent3D i_extent,
            VkFormat i_format,
            VkImageType i_imageType,
            VkImage_T* i_ptr_image,
            VmaAllocation* i_ptr_allocation)
        {
            m_id = ResId.GetNextId();
            m_label = i_label;
            m_device = i_device;
            m_isWrapper = i_isWrapper;
            m_mipLevelCount = i_mipLevelCount;
            m_arrayLayersCount = ONE;
            m_sampleCount = i_sampleCount;
            m_extent = i_extent;
            m_format = i_format;
            m_imageType = i_imageType;
            m_ptr_image = i_ptr_image;
            m_ptr_allocation = i_ptr_allocation;
            m_layerBarriers = new(ONE, i_mipLevelCount);
        }
    }
}
