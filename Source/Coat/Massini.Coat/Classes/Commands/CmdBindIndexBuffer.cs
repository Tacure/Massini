using Massini.Coat.Enums;
using Massini.Coat.Enums.Internal;

namespace Massini.Coat.Classes.Commands
{
    internal sealed class CmdBindIndexBuffer : Command
    {
        public Buffer? p_buffer = null;
        public IndexFormat p_indexFormat = IndexFormat.None;
        public ulong p_offset = 0;
        public ulong p_size = 0;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdBindIndexBuffer;

        public override void Reset()
        {
            p_buffer = null;
            p_indexFormat = IndexFormat.None;
            p_offset = 0;
            p_size = 0;
        }
    }
}
