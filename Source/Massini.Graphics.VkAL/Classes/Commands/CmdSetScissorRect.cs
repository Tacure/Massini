using Massini.Graphics.VkAL.Enums.Internal;

namespace Massini.Graphics.VkAL.Classes.Commands
{
    internal sealed class CmdSetScissorRect : Command
    {
        public uint p_x; 
        public uint p_y; 
        public uint p_width; 
        public uint p_height;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdSetScissorRect;

        public override void Reset()
        {
            p_x = 0;
            p_y = 0;
            p_width = 0;
            p_height = 0;
        }
    }
}
