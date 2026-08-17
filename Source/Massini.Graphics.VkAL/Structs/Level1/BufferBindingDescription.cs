using Buffer = Massini.Graphics.VkAL.Classes.Buffer;

namespace Massini.Graphics.VkAL.Structs.Level1
{
    public struct BufferBindingDescription
    {
        public required Buffer? p_buffer;
        public required ulong p_offset;
        public required ulong p_range;
    }
}
