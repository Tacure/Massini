using Massini.Flamet.Enums.Internal;

namespace Massini.Flamet.Classes.Commands
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
