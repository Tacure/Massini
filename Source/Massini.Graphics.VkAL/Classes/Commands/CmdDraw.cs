using Massini.Graphics.VkAL.Enums.Internal;

namespace Massini.Graphics.VkAL.Classes.Commands
{
    internal sealed class CmdDraw : Command
    {
        public uint p_vertexCount = 0;
        public uint p_instanceCount = 0;
        public uint p_firstVertex = 0; 
        public uint p_firstInstance = 0;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdDraw;

        public override void Reset()
        {
            p_vertexCount = 0;
            p_instanceCount = 0;
            p_firstVertex = 0;
            p_firstInstance = 0;
        }
    }
}
