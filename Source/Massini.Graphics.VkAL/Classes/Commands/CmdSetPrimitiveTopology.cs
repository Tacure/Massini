
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Enums.Internal;

namespace Massini.Graphics.VkAL.Classes.Commands
{
    internal sealed class CmdSetPrimitiveTopology : Command
    {
        public PrimitiveTopology p_primitiveTopology = PrimitiveTopology.TriangleList;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdSetPrimitiveTopology;

        public override void Reset()
        {
            p_primitiveTopology = PrimitiveTopology.TriangleList;
        }
    }
}
