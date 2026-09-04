using Buffer = Massini.Flamet.Classes.Buffer;

namespace Massini.Flamet.Structs.Level1
{
    public struct BufferBindingDescription
    {
        public required Buffer? p_buffer;
        public required ulong p_offset;
        public required ulong p_range;
    }
}
