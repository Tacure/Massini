
using Massini.Graphics.VkAL.Enums.Internal;

namespace Massini.Graphics.VkAL.Classes.Commands
{
    internal sealed class CmdSetStencilTestEnable : Command
    {
        public bool p_stencilTestEnable = false;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdSetStencilTestEnable;

        public override void Reset()
        {
            p_stencilTestEnable = false;
        }
    }
}
