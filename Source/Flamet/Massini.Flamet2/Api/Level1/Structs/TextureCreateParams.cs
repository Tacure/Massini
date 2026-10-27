
using Massini.Core.Math.Primitives;
using Massini.Flamet2.Api.Level1.Enums;
using Massini.Flamet2.Api.Level1.Interfaces;

namespace Massini.Flamet2.Api.Level1.Structs
{
    /// <summary>
    /// Texture creation parameters.
    /// </summary>
    public struct TextureCreateParams
    {
        public required TextureType p_type;
        public required TextureFormat p_format;
        /// <summary>
        /// Extent of the texture in pixels.
        /// </summary>
        public required Vec3<uint> p_size;
        public required SampleCount p_sampleCount;
        public required uint p_mipLevelCount;
        public required uint p_arrayLayers;
        /// <summary>
        /// How the texture will be used.
        /// </summary>
        public required TextureUsageFlags p_usage;
        public required ILane1 p_initialLane;
    }
}