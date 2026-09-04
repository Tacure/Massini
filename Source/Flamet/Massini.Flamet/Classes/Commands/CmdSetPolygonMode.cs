using Massini.Flamet.Enums;
using Massini.Flamet.Enums.Internal;

namespace Massini.Flamet.Classes.Commands
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
