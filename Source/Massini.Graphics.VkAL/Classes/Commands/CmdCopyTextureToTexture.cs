using Massini.Graphics.VkAL.Enums.Internal;
using Massini.Graphics.VkAL.Structs.Level1;

namespace Massini.Graphics.VkAL.Classes.Commands
{
    internal sealed class CmdCopyTextureToTexture : Command
    {
        public Texture? p_srcTexture = null;
        public Texture? p_dstTexture = null;
        public TextureCopy[] p_regions = [];

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdCopyTextureToTexture;

        public override void Reset()
        {
            p_srcTexture = null;
            p_dstTexture = null;
            p_regions = [];
        }
    }
}
