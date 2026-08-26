using Massini.Coat.Enums;
using Massini.Coat.Interfaces;

namespace Massini.Coat.Structs.Level1
{
    public struct BufferCreateParams : INext
    {
        public required INext? p_next;
        public required string p_label;
        public required BufferType p_type;
        public required BufferUsageFlags p_usage;
        /// <summary>
        /// Number of bytes to allocate for the buffer.
        /// </summary>
        public required ulong p_size;

        public readonly INext? Next => p_next;
    }
}
