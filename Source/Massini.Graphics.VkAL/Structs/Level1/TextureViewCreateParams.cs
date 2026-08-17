using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Interfaces;

namespace Massini.Graphics.VkAL.Structs.Level1
{
    public struct TextureViewCreateParams : INext
    {
        public required INext? p_next;
        public required string p_label;
        public required TextureViewType p_type;
        public required TextureFormat p_format;
        public required TextureAspectFlags p_aspect;
        public required SampleCount p_sampleCount;
        public required uint p_mipLevelCount;
        public required TextureUsageFlags p_usage;
        public required uint p_baseMipLevel;
        public required uint p_baseArrayLayer;
        public required uint p_layerCount;

        public readonly INext? Next => p_next;
    }
}
