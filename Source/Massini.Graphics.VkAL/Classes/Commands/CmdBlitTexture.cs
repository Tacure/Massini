
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Enums.Internal;
using Massini.Graphics.VkAL.Structs.Level1;

namespace Massini.Graphics.VkAL.Classes.Commands
{
    internal class CmdBlitTexture : Command
    {
        public Texture? p_srcTexture; 
        public Texture? p_dstTexture; 
        public TextureBlit[] p_regions = [];
        public FilterMode p_filterMode;

        public override VirtualCommandKind CommandKind => VirtualCommandKind.CmdBlitTexture;

        public override void Reset()
        {
            p_srcTexture = null;
            p_dstTexture = null;
            p_regions = [];
            p_filterMode = FilterMode.Nearest;
        }
    }
}
