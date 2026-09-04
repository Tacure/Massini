using Massini.Flamet.Enums.Internal;

namespace Massini.Flamet.Classes.Commands
{
    internal sealed class CmdSetAlphaToCoverageEnable : Command
    {
        public bool p_alphaToCoverageEnable = false;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdSetAlphaToCoverageEnable;

        public override void Reset()
        {
            p_alphaToCoverageEnable = false;
        }
    }
}
