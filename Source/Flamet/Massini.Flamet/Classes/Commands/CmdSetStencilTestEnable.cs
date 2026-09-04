using Massini.Flamet.Enums.Internal;

namespace Massini.Flamet.Classes.Commands
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
