
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Enums.Internal;

namespace Massini.Graphics.VkAL.Classes.Commands
{
    internal sealed class CmdSetPolygonMode : Command
    {
        public PolygonMode p_polygonMode = PolygonMode.Fill;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdSetPolygonMode;

        public override void Reset()
        {
            p_polygonMode = PolygonMode.Fill;
        }
    }
}
