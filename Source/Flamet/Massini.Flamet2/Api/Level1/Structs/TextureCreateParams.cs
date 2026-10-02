
using Massini.Core.Math.Primitives;
using Massini.Flamet2.Api.Level1.Enums;

namespace Massini.Flamet2.Api.Level1.Structs
{
    public struct TextureCreateParams
    {
        public required TextureType p_type;
        public required TextureFormat p_format;
        public required Vec3<uint> p_size;
        public required SampleCount p_sampleCount;
        public required uint p_mipLevelCount;
        public required uint p_arrayLayers;
        public required TextureUsageFlags p_usage;
    }
}