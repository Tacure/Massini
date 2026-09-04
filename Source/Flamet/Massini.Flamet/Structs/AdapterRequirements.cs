using Massini.Flamet.Interfaces;

namespace Massini.Flamet.Structs
{
    public struct AdapterRequirements : INext
    {
        public required INext? p_next;

        public readonly INext? Next => p_next;
    }
}
