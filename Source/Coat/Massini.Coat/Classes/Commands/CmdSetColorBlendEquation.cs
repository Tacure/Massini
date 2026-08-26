
using Massini.Coat.Enums.Internal;
using Massini.Coat.Structs.Level1;

namespace Massini.Coat.Classes.Commands
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
