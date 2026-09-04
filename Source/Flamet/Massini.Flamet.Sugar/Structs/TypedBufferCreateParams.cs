using Massini.Flamet.Enums;
using Massini.Flamet.Interfaces;

namespace Massini.Flamet.Sugar.Structs
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
