
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Enums.Internal;

namespace Massini.Graphics.VkAL.Classes.Commands
{
    internal sealed class CmdSetFrontFace : Command
    {
        public FrontFace p_frontFace = FrontFace.Clockwise;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdSetFrontFace;

        public override void Reset()
        {
            p_frontFace = FrontFace.Clockwise;
        }
    }
}
