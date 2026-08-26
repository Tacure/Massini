
using Massini.Coat.Enums;
using Massini.Coat.Enums.Internal;

namespace Massini.Coat.Classes.Commands
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
