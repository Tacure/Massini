
using Massini.Graphics.VkAL.Enums.Internal;

namespace Massini.Graphics.VkAL.Classes.Commands
{
    internal sealed class CmdSetDepthClampEnable : Command
    {
        public bool p_depthClampEnable = false;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdSetDepthClampEnable;

        public override void Reset()
        {
            p_depthClampEnable = false;
        }
    }
}
