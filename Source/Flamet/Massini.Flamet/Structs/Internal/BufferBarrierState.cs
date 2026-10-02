
using Massini.Bindings.Vulkan;

namespace Massini.Flamet.Structs.Internal
{
    public struct BufferBarrierState
    {
        public VkAccessFlagBits p_accessMask = VkAccessFlagBits.VK_ACCESS_NONE;
        public VkPipelineStageFlagBits p_stageMask = VkPipelineStageFlagBits.VK_PIPELINE_STAGE_TOP_OF_PIPE_BIT;

        public BufferBarrierState()
        {
        }
    }   
}