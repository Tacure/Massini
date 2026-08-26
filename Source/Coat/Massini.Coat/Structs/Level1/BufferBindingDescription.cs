using Buffer = Massini.Coat.Classes.Buffer;

namespace Massini.Coat.Structs.Level1
{
    public struct BufferBindingDescription
    {
        public required Buffer? p_buffer;
        public required ulong p_offset;
        public required ulong p_range;
    }
}
