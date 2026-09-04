using Massini.Flamet.Interfaces;

namespace Massini.Flamet.Structs.Level1
{
    public struct CommandListCreateParams : INext
    {
        public required INext? p_next;
        public required string p_label;

        public readonly INext? Next => p_next;
    }
}
