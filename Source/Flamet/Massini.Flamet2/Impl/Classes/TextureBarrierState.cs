
using Massini.Bindings.Vulkan;
using Massini.Core.Collections;

namespace Massini.Flamet2.Impl.Classes
{
    internal sealed class TextureBarrierState
    {
        internal struct TextureSubresourceBarrierState
        {
            internal VkImageLayout p_layout;
            internal VkAccessFlagBits p_accessMask;
            internal VkPipelineStageFlagBits p_stageMask;
            internal uint p_queueFamilyIndex;
        }

        internal TextureBarrierState(uint i_layerCount, uint i_mipCount, uint i_queueFamilyIndex)
        {
            m_layerCount = i_layerCount;
            m_mipCount = i_mipCount;

            m_states = [with((int)i_layerCount, (int)i_mipCount)];

            for (int i = 0; i < m_states.Count; i++)
            {
                ref TextureSubresourceBarrierState state = ref m_states[i];
                
                state.p_layout = VkImageLayout.VK_IMAGE_LAYOUT_UNDEFINED;
                state.p_accessMask = VkAccessFlagBits.VK_ACCESS_NONE;
                state.p_stageMask = VkPipelineStageFlagBits.VK_PIPELINE_STAGE_TOP_OF_PIPE_BIT;
                state.p_queueFamilyIndex = i_queueFamilyIndex;
            }
        }

        internal ref TextureSubresourceBarrierState GetState(uint i_layer, uint i_mip)
        {
            return ref m_states[(int)i_layer, (int)i_mip];
        }

        private readonly uint m_layerCount;
        private readonly uint m_mipCount;
        private readonly FlatArray2D<TextureSubresourceBarrierState> m_states;
    }
}