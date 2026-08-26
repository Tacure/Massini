
using Massini.Coat.Classes;
using Massini.Coat.Interfaces;

namespace Massini.Coat.Structs.Level1
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
