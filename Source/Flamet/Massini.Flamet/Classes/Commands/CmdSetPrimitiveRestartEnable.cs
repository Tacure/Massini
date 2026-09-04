using Massini.Flamet.Enums.Internal;

namespace Massini.Flamet.Classes.Commands
{
    internal sealed class CmdSetPrimitiveRestartEnable : Command
    {
        public bool p_primitiveRestartEnable = false;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdSetPrimitiveRestartEnable;

        public override void Reset()
        {
            p_primitiveRestartEnable = false;
        }
    }
}
