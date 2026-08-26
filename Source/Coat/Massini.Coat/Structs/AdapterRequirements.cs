
using Massini.Coat.Interfaces;

namespace Massini.Coat.Structs
{
    public struct AdapterRequirements : INext
    {
        public required INext? p_next;

        public readonly INext? Next => p_next;
    }
}
