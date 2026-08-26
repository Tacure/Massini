using Massini.Coat.Enums;
using Massini.Coat.Interfaces;

namespace Massini.Coat.Sugar.Structs
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
