
using Massini.Bindings.Vulkan;
using Massini.Flamet2.Api.Level1.Interfaces;

namespace Massini.Flamet2.Impl.Structs
{
    public unsafe struct CommandListSemaphoreSubmitParams : INext
    {
        public INext? p_next;
        public required VkSemaphore_T*[] p_waitBinarySemaphores;
        public required VkSemaphore_T*[] p_signalBinarySemaphores;

        public readonly INext? Next => p_next;
    }
}