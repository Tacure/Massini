using Massini.Coat.Enums;

namespace Massini.Coat.Structs.Level1
{
    public struct TextureSubresourceLayers
    {
        public required TextureAspectFlags p_aspectMask;
        public required uint p_mipLevel;
        public required uint p_baseArrayLayer;
        public required uint p_layerCount;
    }
}
