
using Massini.Coat.Enums.Internal;

namespace Massini.Coat.Classes.Commands
{
    internal sealed class CmdSetDepthWriteEnable : Command
    {
        public bool p_depthWriteEnable = false;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdSetDepthWriteEnable;

        public override void Reset()
        {
            p_depthWriteEnable = false;
        }
    }   
}
