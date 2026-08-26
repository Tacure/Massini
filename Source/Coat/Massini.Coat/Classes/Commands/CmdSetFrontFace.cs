
using Massini.Coat.Enums;
using Massini.Coat.Enums.Internal;

namespace Massini.Coat.Classes.Commands
{
    internal sealed class CmdSetFrontFace : Command
    {
        public FrontFace p_frontFace = FrontFace.Clockwise;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdSetFrontFace;

        public override void Reset()
        {
            p_frontFace = FrontFace.Clockwise;
        }
    }
}
