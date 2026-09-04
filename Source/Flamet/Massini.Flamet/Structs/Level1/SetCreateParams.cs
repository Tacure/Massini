
using Massini.Flamet.Classes;
using Massini.Flamet.Interfaces;

namespace Massini.Flamet.Structs.Level1
{
    public struct SetCreateParams : INext
    {
        public required INext? p_next;
        public required string p_label;
        public required uint p_setLayoutIdx;
        public required SetEntryBinding[] p_bindings;

        public readonly INext? Next => p_next;
    }
}
