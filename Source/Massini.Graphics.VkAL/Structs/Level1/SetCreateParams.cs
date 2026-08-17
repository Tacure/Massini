
using Massini.Graphics.VkAL.Classes;
using Massini.Graphics.VkAL.Interfaces;

namespace Massini.Graphics.VkAL.Structs.Level1
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
