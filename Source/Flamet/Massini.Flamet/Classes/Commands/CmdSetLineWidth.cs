using Massini.Flamet.Enums.Internal;

namespace Massini.Flamet.Classes.Commands
{
    internal sealed class CmdSetLineWidth : Command
    {
        public float p_lineWidth = 1.0f;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdSetLineWidth;

        public override void Reset()
        {
            p_lineWidth = 1.0f;
        }
    }
}
