using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Interfaces;

namespace Massini.Graphics.VkAL.Sugar.Structs
{
    public struct TypedBufferCreateParams : INext
    {
        public required INext? p_next;
        public required string p_label;
        public required BufferUsageFlags p_usage;
        /// <summary>
        /// Number of elements.
        /// </summary>
        public required ulong p_count;

        public readonly INext? Next => p_next;
    }
}
