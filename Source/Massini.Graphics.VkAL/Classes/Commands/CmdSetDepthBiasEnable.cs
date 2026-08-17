
using Massini.Graphics.VkAL.Enums.Internal;

namespace Massini.Graphics.VkAL.Classes.Commands
{
    internal sealed class CmdSetDepthBiasEnable : Command
    {
        public bool p_depthBiasEnable = false;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdSetDepthBiasEnable;

        public override void Reset()
        {
            p_depthBiasEnable = false;
        }
    }
}
