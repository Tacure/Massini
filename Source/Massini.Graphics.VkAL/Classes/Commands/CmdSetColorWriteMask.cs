
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Enums.Internal;

namespace Massini.Graphics.VkAL.Classes.Commands
{
    internal sealed class CmdSetColorWriteMask : Command
    {
        public uint p_firstAttachment = 0; 
        public ColorComponentFlags[]? p_colorWriteMasks = null;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdSetColorWriteMask;


        public override void Reset()
        {
            p_firstAttachment = 0;
            p_colorWriteMasks = null;
        }
    }
}