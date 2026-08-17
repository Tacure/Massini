
using Massini.Graphics.VkAL.Enums.Internal;

namespace Massini.Graphics.VkAL.Classes.Commands
{
    internal sealed class CmdSetPrimitiveRestartEnable : Command
    {
        public bool p_primitiveRestartEnable = false;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdSetPrimitiveRestartEnable;

        public override void Reset()
        {
            p_primitiveRestartEnable = false;
        }
    }
}
