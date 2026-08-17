
using Massini.Graphics.VkAL.Classes;
using Massini.Graphics.VkAL.Interfaces;

namespace Massini.Graphics.VkAL.Structs.Level1
{
    public struct SwapchainBeginFrameParams : INext
    {
        public required INext? p_next;
        public required Queue p_presentQueue;
        public required CommandList[] p_waitCommandLists;

        public readonly INext? Next => p_next;
    }
}
