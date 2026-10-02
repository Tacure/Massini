
using Massini.Bindings.Vulkan;
using Massini.Core;
using Massini.Flamet2.Api.Level1.Classes;
using Massini.Flamet2.Api.Level1.Interfaces;
using Massini.Flamet2.Api.Level1.Structs;

namespace Massini.Flamet2.Impl.Classes
{
    internal sealed unsafe class TextureView : ITextureView1
    {
        public TextureView(Texture i_texture, in TextureViewCreateParams i_createParams)
        {
            Device device = (Device)i_texture.GetLane().GetInfo().Device;
            
            VkImageViewCreateInfo imageViewCreateInfo = new()
            {
                sType = VkStructureType.VK_STRUCTURE_TYPE_IMAGE_VIEW_CREATE_INFO,
                pNext = null,
                flags = 0,
                image = i_texture.VkImagePtr,
                viewType = IntSharedCvs.TextureViewTypeToVkImageViewType(i_createParams.p_type),
                subresourceRange = new VkImageSubresourceRange
                {
                    aspectMask = (uint)IntSharedCvs.TextureAspectFlagsToVkImageAspectFlagBits(i_createParams.p_aspect),
                    baseMipLevel = i_createParams.p_baseMipLevel,
                    baseArrayLayer = i_createParams.p_baseArrayLayer,
                    layerCount = i_createParams.p_layerCount,
                    levelCount = i_createParams.p_mipLevelCount
                },
                components = new VkComponentMapping
                {
                    r = VkComponentSwizzle.VK_COMPONENT_SWIZZLE_IDENTITY,
                    g = VkComponentSwizzle.VK_COMPONENT_SWIZZLE_IDENTITY,
                    b = VkComponentSwizzle.VK_COMPONENT_SWIZZLE_IDENTITY,
                    a = VkComponentSwizzle.VK_COMPONENT_SWIZZLE_IDENTITY,
                },
                format = IntSharedCvs.TextureFormatToVkFormat(i_createParams.p_format),
            };

            VkImageView_T* imageView = null;
            VkResult result = Vk.vkCreateImageView(device.VkDevicePtr, &imageViewCreateInfo, null, &imageView);
            if (result != VkResult.VK_SUCCESS)
            {
                throw new Exception("Failed to create image view.");
            }

            m_texture = i_texture;
            m_ptr_imageView = imageView;

            m_textureViewInfo = new TextureViewInfo()
            {
                Id = Rid.NewId(),
                Texture = m_texture,
                TextureViewType = i_createParams.p_type,
            };
        }

        public void Dispose()
        {
            if (!m_isDisposed)
            {
                Device device = (Device)m_texture.GetLane().GetInfo().Device;
                
                m_isDisposed = true;
                Vk.vkDestroyImageView(device.VkDevicePtr, m_ptr_imageView, null);
            }
        }

        public TextureViewInfo GetInfo()
        {
            return m_textureViewInfo;
        }

        public void SetLabel(string i_label)
        {
            if (m_isDisposed) return;
            
            Device device = (Device)m_texture.GetLane().GetInfo().Device;
            IntSharedFuncs.SetObjectLabel(device, m_ptr_imageView, VkObjectType.VK_OBJECT_TYPE_IMAGE_VIEW, i_label);
        }

        private bool m_isDisposed = false;
        private readonly Texture m_texture;
        private readonly VkImageView_T* m_ptr_imageView;
        private readonly TextureViewInfo m_textureViewInfo;
    }   
}