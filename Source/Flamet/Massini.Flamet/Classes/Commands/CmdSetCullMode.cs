using Massini.Flamet.Enums;
using Massini.Flamet.Enums.Internal;

namespace Massini.Flamet.Classes.Commands
{
    internal sealed class CmdSetCullMode : Command
    {
        public CullMode p_cullMode;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdSetCullMode;

        public override void Reset()
        {
            p_cullMode = CullMode.None;
        }
    }
}