using Massini.Flamet.Enums;
using Massini.Flamet.Enums.Internal;

namespace Massini.Flamet.Classes.Commands
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
