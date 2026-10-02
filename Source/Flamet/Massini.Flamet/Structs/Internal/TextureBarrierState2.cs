using System.Runtime.CompilerServices;
using Massini.Bindings.Vulkan;
using Massini.Core.Interop;

namespace Massini.Flamet.Structs.Internal
{
    public unsafe struct TextureBarrierState2
    {
        public struct TextureSubresourceBarrierState
        {
            public VkImageLayout p_layout;
            public VkAccessFlagBits p_accessMask;
            public VkPipelineStageFlagBits p_stageMask;
        }

        public TextureBarrierState2(ArenaAllocator i_allocator, uint i_layerCount, uint i_mipCount)
        {
            m_layerCount = i_layerCount;
            m_mipCount = i_mipCount;

            m_states = i_allocator.Alloc<TextureSubresourceBarrierState>((int)(i_layerCount * i_mipCount), MemorySize.FromBytes(8));

            for (int i = 0; i < m_states.Capacity; i++)
            {
                TextureSubresourceBarrierState* state = m_states.RawPtrAt(i);
                state->p_accessMask = VkAccessFlagBits.VK_ACCESS_NONE;
                state->p_layout = VkImageLayout.VK_IMAGE_LAYOUT_GENERAL;
                state->p_stageMask = VkPipelineStageFlagBits.VK_PIPELINE_STAGE_NONE;
            }
        }

        public ref TextureSubresourceBarrierState GetState(uint i_layer, uint i_mip)
        {
            return ref Unsafe.AsRef<TextureSubresourceBarrierState>(m_states.RawPtrAt(GetIndex((int)i_layer, (int)i_mip)));
        }

        private readonly uint m_layerCount;
        private readonly uint m_mipCount;
        private ArenaAlloc<TextureSubresourceBarrierState> m_states;
        
        private int GetIndex(int i_x, int i_y)
        {
            return (int)(i_x + i_y * m_layerCount);
        }
    }   
}