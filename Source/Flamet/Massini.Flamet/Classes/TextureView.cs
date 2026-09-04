
using Massini.Bindings.Vulkan;
using Massini.Core;
using Massini.Flamet.Structs;
using Massini.Flamet.Enums;
using Massini.Flamet.Interfaces;
using Massini.Flamet.Structs.Level1;

namespace Massini.Flamet.Classes
{
    public unsafe partial class TextureView : IResource, IDisposable
    {
        /// <inheritdoc/>
        public Rid Id => m_id;

        /// <inheritdoc/>
        public bool IsDisposed => m_isDisposed;

        /// <inheritdoc/>
        public Device Device => m_texture.Device;

        public Texture Texture => m_texture;

        public TextureFormat Format => Texture.Format;

        public TextureViewType Type => m_type;

        public TextureAspectFlags Aspect => m_aspectFlags;

        public TextureView(Texture i_texture, in TextureViewCreateParams i_createParams)
        {
            Texture texture = (Texture)i_texture;

            VkImageViewCreateInfo imageViewCreateInfo = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_IMAGE_VIEW_CREATE_INFO,
                pNext = null,
                flags = 0,
                image = texture.VkImagePtr,
                viewType = IntSharedCvs.TextureViewTypeToVkImageViewType(i_createParams.p_type),
                subresourceRange = new()
                {
                    aspectMask = (uint)IntSharedCvs.TextureAspectFlagsToVkImageAspectFlagBits(i_createParams.p_aspect),
                    baseMipLevel = i_createParams.p_baseMipLevel,
                    baseArrayLayer = i_createParams.p_baseArrayLayer,
                    layerCount = i_createParams.p_layerCount,
                    levelCount = i_createParams.p_mipLevelCount
                },
                components = new()
                {
                    r = VkComponentSwizzle.VK_COMPONENT_SWIZZLE_IDENTITY,
                    g = VkComponentSwizzle.VK_COMPONENT_SWIZZLE_IDENTITY,
                    b = VkComponentSwizzle.VK_COMPONENT_SWIZZLE_IDENTITY,
                    a = VkComponentSwizzle.VK_COMPONENT_SWIZZLE_IDENTITY,
                },
                format = IntSharedCvs.TextureFormatToVkFormat(i_createParams.p_format),
            };

            VkImageView_T* imageView = null;
            VkResult result = Vk.vkCreateImageView(texture.Device.VkDevicePtr, &imageViewCreateInfo, null, &imageView);
            if (result != VkResult.VK_SUCCESS)
            {
                throw new Exception("Failed to create image view.");
            }

            IntSharedFuncs.SetObjectLabel(i_texture.Device, imageView, VkObjectType.VK_OBJECT_TYPE_IMAGE_VIEW, $"{i_createParams.p_type} - {i_createParams.p_label}");

            m_id = Rid.NewId();
            m_texture = texture;
            m_type = i_createParams.p_type;
            m_aspectFlags = i_createParams.p_aspect;
            m_ptr_imageView = imageView;
        }

        public void Dispose()
        {
            if (!m_isDisposed)
            {
                m_isDisposed = true;
                GC.SuppressFinalize(this);
                Vk.vkDestroyImageView(m_texture.Device.VkDevicePtr, m_ptr_imageView, null);
            }
        }
    }

    public unsafe partial class TextureView 
    {
        internal VkImageView_T* VkImageViewPtr => m_ptr_imageView;

        private bool m_isDisposed = false;
        private readonly string m_label;
        private readonly Rid m_id;
        private readonly TextureViewType m_type;
        private readonly TextureAspectFlags m_aspectFlags;
        private readonly Texture m_texture;
        private readonly VkImageView_T* m_ptr_imageView = null;

        private TextureView(string i_label, TextureViewType i_type, TextureAspectFlags i_aspect, Texture i_texture, VkImageView_T* i_ptr_imageView)
        {
            m_label = i_label;
            m_type = i_type;
            m_aspectFlags = i_aspect;
            m_texture = i_texture;
            m_ptr_imageView = i_ptr_imageView;
        }
    }
}
