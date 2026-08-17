using Massini.Graphics.VkAL.Enums.Internal;
using Massini.Graphics.VkAL.Structs.Level1;

namespace Massini.Graphics.VkAL.Classes.Commands
{
    internal sealed class CmdCopyBufferToTexture : Command
    {
        public Buffer? p_srcBuffer;
        public Texture? p_dstTexture;
        public BufferTextureCopy[] p_regions = [];

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdCopyBufferToTexture;

        public override void Reset()
        {
            p_srcBuffer = null;
            p_dstTexture = null;
            p_regions = [];
        }
    }
}
