
using Massini.Graphics.VkAL.Enums;

namespace Massini.Graphics.VkAL.Structs.Level1
{
    public struct BlendState
    {
        public required BlendFactor p_srcColorBlendFactor;
        public required BlendFactor p_dstColorBlendFactor;
        public required BlendOp p_colorBlendOp;
        public required BlendFactor p_srcAlphaBlendFactor;
        public required BlendFactor p_dstAlphaBlendFactor;
        public required BlendOp p_alphaBlendOp;
        public required ColorComponentFlags p_colorWriteMask;
    }
}
