
using Massini.Coat.Enums;
using Massini.Coat.Enums.Internal;

namespace Massini.Coat.Classes.Commands
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