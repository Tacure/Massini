
using Massini.Coat.Enums.Internal;

namespace Massini.Coat.Classes.Commands
{
    internal sealed class CmdSetStencilTestEnable : Command
    {
        public bool p_stencilTestEnable = false;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdSetStencilTestEnable;

        public override void Reset()
        {
            p_stencilTestEnable = false;
        }
    }
}
