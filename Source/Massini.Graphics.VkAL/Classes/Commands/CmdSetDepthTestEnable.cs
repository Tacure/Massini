
using Massini.Graphics.VkAL.Enums.Internal;

namespace Massini.Graphics.VkAL.Classes.Commands
{
    internal sealed class CmdSetDepthTestEnable : Command
    {
        public bool p_depthTestEnable;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdSetDepthTestEnable;

        public override void Reset()
        {
            p_depthTestEnable = false;
        }
    }
}
