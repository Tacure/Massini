using Massini.Flamet.Enums.Internal;
using Massini.Flamet.Structs.Level1;

namespace Massini.Flamet.Classes.Commands
{
    internal sealed class CmdCopyBufferToBuffer : Command
    {
        public Buffer? p_srcBuffer = null;
        public Buffer? p_dstBuffer = null;
        public BufferCopy[] p_bufferCopies = [];

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdCopyBufferToBuffer;

        public override void Reset()
        {
            p_srcBuffer = null;
            p_dstBuffer = null;
            p_bufferCopies = [];
        }
    }
}
