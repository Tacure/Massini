
using Massini.Coat.Enums;
using Massini.Coat.Enums.Internal;

namespace Massini.Coat.Classes.Commands
{
    internal sealed class CmdSetDepthCompareOp : Command
    {
        public CompareOp p_depthCompareOp = CompareOp.Never;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdSetDepthCompareOp;

        public override void Reset()
        {
            p_depthCompareOp = CompareOp.Never;
        }
    }
}
