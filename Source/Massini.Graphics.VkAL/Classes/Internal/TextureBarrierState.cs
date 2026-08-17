
using Massini.Bindings.Vulkan;
using Massini.Collections;

namespace Massini.Graphics.VkAL.Classes.Internal
{
    internal class TextureBarrierState
    {
        public struct TextureSubresourceBarrierState
        {
            public VkImageLayout p_layout;
            public VkAccessFlagBits p_accessMask;
            public VkPipelineStageFlagBits p_stageMask;
        }

        public TextureBarrierState(uint i_layerCount, uint i_mipCount)
        {
            m_layerCount = i_layerCount;
            m_mipCount = i_mipCount;

            m_states = new((int)i_layerCount, (int)i_mipCount);

            for (int i = 0; i < m_states.Count; i++)
            {
                m_states[i].p_layout = VkImageLayout.VK_IMAGE_LAYOUT_UNDEFINED;
                m_states[i].p_accessMask = VkAccessFlagBits.VK_ACCESS_NONE;
                m_states[i].p_stageMask = VkPipelineStageFlagBits.VK_PIPELINE_STAGE_TOP_OF_PIPE_BIT;
            }
        }

        public ref TextureSubresourceBarrierState GetState(uint i_layer, uint i_mip)
        {
            return ref m_states.GetRefAt((int)i_layer, (int)i_mip);
        }

        private readonly uint m_layerCount;
        private readonly uint m_mipCount;
        private readonly FlatArray2D<TextureSubresourceBarrierState> m_states;
    }
}