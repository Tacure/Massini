
using Massini.Core;
using Massini.Core.Interop;
using Massini.Flamet2.Api.Level1.Enums;
using Massini.Flamet2.Api.Level1.Interfaces;

namespace Massini.Flamet2.Api.Level1.Classes
{
    /// <summary>
    /// Buffer information.
    /// </summary>
    public sealed class BufferInfo
    {
        /// <summary>
        /// Unique id for this buffer.
        /// </summary>
        public Rid Id { get; init; }
        /// <summary>
        /// The device that created this buffer.
        /// </summary>
        public IDevice1 Device { get; init; }
        /// <summary>
        /// Buffer type.
        /// </summary>
        public BufferType BufferType { get; init; }
        /// <summary>
        /// Buffer size.
        /// </summary>
        public MemorySize Size { get; set; }
    }   
}