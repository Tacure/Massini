using Massini.Flamet.Enums;
using Massini.Flamet.Enums.Internal;

namespace Massini.Flamet.Classes.Commands
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
