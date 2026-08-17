using Massini.Graphics.VkAL.Enums.Internal;

namespace Massini.Graphics.VkAL.Classes.Commands
{
    internal sealed class CmdBindVertexBuffer : Command
    {
        public Buffer? p_buffer = null;
        public uint p_firstBinding = 0;
        public ulong p_offset = 0;
        public ulong p_size = 0;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdBindVertexBuffer;

        public override void Reset()
        {
            p_buffer = null;
            p_firstBinding = 0;
            p_offset = 0;
            p_size = 0;
        }
    }
}
