
using Massini.Graphics.VkAL.Classes;
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Interfaces;

namespace Massini.Graphics.VkAL.Structs
{
    public struct SurfaceCreateParams : INext
    {
        public required INext? p_next;
        public required string p_label;

        public readonly INext? Next => p_next;
    }
}
