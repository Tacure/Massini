
using Massini.Bindings.Vulkan;

namespace Massini.Flamet2.Impl.Classes
{
    internal sealed class BufferBarrierState
    {
        internal BufferBarrierState(uint i_queueFamilyIdx)
        {
            m_queueFamilyIndex = i_queueFamilyIdx;
        }
        
        internal uint QueueFamilyIndex
        {
            get => m_queueFamilyIndex;
            set => m_queueFamilyIndex = value;
        }

        internal VkAccessFlagBits VkAccessMask
        {
            get => m_accessMask;
            set => m_accessMask = value;
        }

        internal VkPipelineStageFlagBits VkStageMask
        {
            get => m_stageMask;
            set => m_stageMask = value;
        }

        private uint m_queueFamilyIndex;
        private VkAccessFlagBits m_accessMask = VkAccessFlagBits.VK_ACCESS_NONE;
        private VkPipelineStageFlagBits m_stageMask = VkPipelineStageFlagBits.VK_PIPELINE_STAGE_TOP_OF_PIPE_BIT;
    }
}