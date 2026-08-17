
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Enums.Internal;

namespace Massini.Graphics.VkAL.Classes.Commands
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
