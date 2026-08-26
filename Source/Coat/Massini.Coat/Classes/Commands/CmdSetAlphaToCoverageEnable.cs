
using Massini.Coat.Enums.Internal;

namespace Massini.Coat.Classes.Commands
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
