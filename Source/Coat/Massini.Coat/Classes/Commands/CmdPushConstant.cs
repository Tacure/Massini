
using Massini.Coat.Enums;
using Massini.Coat.Enums.Internal;

namespace Massini.Coat.Classes.Commands
{
    internal class CmdPushConstant : Command
    {        internal ShaderStageFlags p_stageFlags = 0;
        internal byte[] p_data = [];

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdPushConstant;

        public override void Reset()
        {
            p_stageFlags = 0;
            p_data = [];
        }
    }
}
