using Massini.Flamet2.Api.Level1.Interfaces;

namespace Massini.Flamet2.Api.Level1.Structs
{
    public struct BufferBindingDescription
    {
        public required IBuffer1 p_buffer;
        public required ulong p_offset;
        public required ulong p_range;
    }
}