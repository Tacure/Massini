
using Massini.Coat.Classes;
using Massini.Coat.Interfaces;

namespace Massini.Coat.Structs.Level1
{
    public struct SwapchainBeginFrameParams : INext
    {
        public required INext? p_next;
        public required Queue p_presentQueue;
        public required CommandList[] p_waitCommandLists;

        public readonly INext? Next => p_next;
    }
}
