using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Interfaces;
using Massini.Core.Math.Primitives;

namespace Massini.Graphics.VkAL.Sugar.Structs
{
    public struct RenderTextureCreateParams : INext
    {
        public required INext? p_next;
        public required string p_label;
        public required Vec2<uint> p_size;
        public required uint p_frames;
        public required TextureFormat[] p_colorFormats;
        public bool p_enableDepthBuffer;
        public required TextureFormat p_depthFormat;

        public readonly INext? Next => p_next;
    }
}
