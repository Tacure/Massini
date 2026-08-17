using Massini.Graphics.VkAL.Enums.Internal;

namespace Massini.Graphics.VkAL.Classes.Commands
{
    internal sealed class CmdDispatch : Command
    {
        public uint p_numGroupsX;
        public uint p_numGroupsY;
        public uint p_numGroupsZ;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdDispatch;

        public override void Reset()
        {
            p_numGroupsX = 0;
            p_numGroupsY = 0;
            p_numGroupsZ = 0;
        }
    }
}
