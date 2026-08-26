
using Massini.Coat.Enums.Internal;

namespace Massini.Coat.Classes.Commands
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
