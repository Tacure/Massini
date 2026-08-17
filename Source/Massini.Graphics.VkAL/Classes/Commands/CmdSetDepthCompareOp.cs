
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Enums.Internal;

namespace Massini.Graphics.VkAL.Classes.Commands
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
