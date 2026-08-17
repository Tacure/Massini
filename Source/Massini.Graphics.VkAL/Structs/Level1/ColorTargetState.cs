using Massini.Graphics.VkAL.Enums;

namespace Massini.Graphics.VkAL.Structs.Level1
{
    public struct ColorTargetState
    {
        public required TextureFormat p_colorFormat;
        public required BlendState? p_blendState;
    }
}
