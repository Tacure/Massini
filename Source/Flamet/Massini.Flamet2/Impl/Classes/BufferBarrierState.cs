
using Massini.Bindings.Vulkan;

namespace Massini.Flamet2.Impl.Classes
{
    internal sealed class BufferBarrierState
    {
        internal VkAccessFlagBits VkAccessMask
        {
            get
            {
                return m_accessMask;
            }
            set
            {
                m_accessMask = value;
            }
        }

        internal VkPipelineStageFlagBits VkStageMask
        {
            get
            {
                return m_stageMask;
            }
            set
            {
                m_stageMask = value;
            }
        }
        
        private VkAccessFlagBits m_accessMask = VkAccessFlagBits.VK_ACCESS_NONE;
        private VkPipelineStageFlagBits m_stageMask = VkPipelineStageFlagBits.VK_PIPELINE_STAGE_TOP_OF_PIPE_BIT;
    }
}