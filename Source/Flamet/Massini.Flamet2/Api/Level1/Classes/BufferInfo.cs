
using Massini.Core;
using Massini.Core.Interop;
using Massini.Flamet2.Api.Level1.Enums;

namespace Massini.Flamet2.Api.Level1.Classes
{
    public sealed class BufferInfo
    {
        public Rid Id { get; init; }
        public BufferType BufferType { get; init; }
        public MemorySize Size { get; set; }
    }   
}