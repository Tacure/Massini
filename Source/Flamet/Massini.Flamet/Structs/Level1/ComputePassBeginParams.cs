using Massini.Flamet.Interfaces;

namespace Massini.Flamet.Structs.Level1
{
    public struct ComputePassBeginParams : INext
    {
        public required INext? p_next;

        public readonly INext? Next => p_next;
    }
}
