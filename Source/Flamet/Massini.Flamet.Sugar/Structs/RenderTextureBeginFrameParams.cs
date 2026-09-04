using Massini.Flamet.Classes;
using Massini.Flamet.Interfaces;

namespace Massini.Flamet.Sugar.Structs
{
    public struct RenderTextureBeginFrameParams : INext
    {
        public required INext? p_next;
        public required Queue p_presentQueue;
        public required CommandList[] p_waitCommandLists;

        public readonly INext? Next => p_next;
    }
}
