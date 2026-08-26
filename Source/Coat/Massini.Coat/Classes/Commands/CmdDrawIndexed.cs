using Massini.Coat.Enums.Internal;

namespace Massini.Coat.Classes.Commands
{
    internal sealed class CmdDrawIndexed : Command
    {
        public uint p_indexCount = 0;
        public uint p_instanceCount = 0;
        public uint p_firstIndex = 0; 
        public int p_vertexOffset = 0; 
        public uint p_firstInstance = 0;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdDrawIndexed;

        public override void Reset()
        {
            p_indexCount = 0;
            p_instanceCount = 0;
            p_firstIndex = 0;
            p_vertexOffset = 0;
            p_firstInstance = 0;
        }
    }
}
