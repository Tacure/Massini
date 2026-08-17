
using Massini.Graphics.VkAL.Enums.Internal;
using Massini.Graphics.VkAL.Structs.Level1;

namespace Massini.Graphics.VkAL.Classes.Commands
{
    internal sealed class CmdSetColorBlendEquation : Command
    {
        public uint p_firstAttachment = 0;
        public BlendState[]? p_blendEquations = null;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdSetColorBlendEquation;

        public override void Reset()
        {
            p_firstAttachment = 0;
            p_blendEquations = null;
        }
    }
}
