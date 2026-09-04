
using Massini.Bindings.Vulkan;
using Massini.Flamet.Interfaces;

namespace Massini.Flamet.Structs.Level1.Internal
{
    internal unsafe struct CommandListSemaphoreSubmitParams : INext
    {
        public required INext? p_next;
        public required VkSemaphore_T*[] p_waitBinarySemaphores;
        public required VkSemaphore_T*[] p_signalBinarySemaphores;

        public readonly INext? Next => p_next;
    }
}
