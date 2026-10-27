
using Massini.Core.Interop;
using Massini.Flamet2.Api.Level1.Enums;
using Massini.Flamet2.Api.Level1.Interfaces;

namespace Massini.Flamet2.Api.Level1.Structs
{
    /// <summary>
    /// Buffer creation parameters.
    /// </summary>
    public struct BufferCreateParams
    {
        /// <summary>
        /// Type of the buffer.
        /// </summary>
        public required BufferType p_type;
        /// <summary>
        /// How the buffer will be used.
        /// </summary>
        public required BufferUsageFlags p_usage;
        /// <summary>
        /// Size of the buffer.
        /// </summary>
        public required MemorySize p_size;
        public required ILane1 p_initialLane;
    }   
}