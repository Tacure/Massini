
using Massini.Coat.Enums.Internal;

namespace Massini.Coat.Classes.Commands
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
