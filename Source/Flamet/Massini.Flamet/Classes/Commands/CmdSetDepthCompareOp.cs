using Massini.Flamet.Enums;
using Massini.Flamet.Enums.Internal;

namespace Massini.Flamet.Classes.Commands
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
