
using Massini.Coat.Enums;
using Massini.Coat.Enums.Internal;

namespace Massini.Coat.Classes.Commands
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
