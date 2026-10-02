
using Massini.Flamet2.Api.Level1.Enums;

namespace Massini.Flamet2.Api.Level1.Structs
{
    public struct TextureViewCreateParams
    {
        public required TextureViewType p_type;
        public required TextureFormat p_format;
        public required TextureAspectFlags p_aspect;
        public required SampleCount p_sampleCount;
        public required uint p_mipLevelCount;
        public required TextureUsageFlags p_usage;
        public required uint p_baseMipLevel;
        public required uint p_baseArrayLayer;
        public required uint p_layerCount;
    }   
}