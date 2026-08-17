using Massini.Graphics.VkAL.Interfaces;

namespace Massini.Graphics.VkAL.Structs.Level1
{
    public struct CommandListCreateParams : INext
    {
        public required INext? p_next;
        public required string p_label;

        public readonly INext? Next => p_next;
    }
}
