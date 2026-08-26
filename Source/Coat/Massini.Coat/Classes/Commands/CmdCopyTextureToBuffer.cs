using Massini.Coat.Enums.Internal;
using Massini.Coat.Structs.Level1;

namespace Massini.Coat.Classes.Commands
{
    internal sealed class CmdCopyTextureToBuffer : Command
    {
        public Texture? p_srcTexture = null;
        public Buffer? p_dstBuffer = null;
        public BufferTextureCopy[] p_regions = [];

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdCopyTextureToBuffer;

        public override void Reset()
        {
            p_srcTexture = null;
            p_dstBuffer = null;
            p_regions = [];
        }
    }
}
