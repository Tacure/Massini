using Massini.Coat.Enums;
using Massini.Coat.Interfaces;
using Massini.Core.Math.Primitives;

namespace Massini.Coat.Structs.Level1
{
    public struct TextureCreateParams : INext
    {
        public required INext? p_next;
        public required string p_label;
        public required TextureType p_type;
        public required TextureFormat p_format;
        public required Vec3<uint> p_size;
        public required SampleCount p_sampleCount;
        public required uint p_mipLevelCount;
        public required uint p_arrayLayers;
        public required TextureUsageFlags p_usage;

        public readonly INext? Next => p_next;
    }
}
