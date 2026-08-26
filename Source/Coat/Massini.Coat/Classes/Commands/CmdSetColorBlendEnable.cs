
using Massini.Coat.Enums.Internal;

namespace Massini.Coat.Classes.Commands
{
    internal sealed class CmdSetColorBlendEnable : Command
    {
        public uint p_firstAttachment = 0;
        public bool[]? p_colorBlendEnable = null;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdSetColorBlendEnable;

        public override void Reset()
        {
            p_firstAttachment = 0;
            p_colorBlendEnable = null;
        }
    }
}
