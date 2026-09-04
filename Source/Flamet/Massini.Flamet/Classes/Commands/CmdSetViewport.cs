using Massini.Flamet.Enums.Internal;

namespace Massini.Flamet.Classes.Commands
{
    internal sealed class CmdSetViewport : Command
    {
        public float p_x;
        public float p_y; 
        public float p_width;
        public float p_height; 
        public float p_minDepth; 
        public float p_maxDepth;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdSetViewport;

        public override void Reset()
        {
            p_x = 0;
            p_y = 0;
            p_width = 0;
            p_height = 0;
            p_minDepth = 0;
            p_maxDepth = 0;
        }
    }
}
