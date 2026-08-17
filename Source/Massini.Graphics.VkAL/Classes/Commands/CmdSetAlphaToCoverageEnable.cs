
using Massini.Graphics.VkAL.Enums.Internal;

namespace Massini.Graphics.VkAL.Classes.Commands
{
    internal sealed class CmdSetAlphaToCoverageEnable : Command
    {
        public bool p_alphaToCoverageEnable = false;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdSetAlphaToCoverageEnable;

        public override void Reset()
        {
            p_alphaToCoverageEnable = false;
        }
    }
}
