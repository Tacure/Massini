using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Interfaces;
using Massini.Core.Math.Primitives;
namespace Massini.Graphics.VkAL.Sugar.Structs
{
    public struct TypedTextureCreateParams : INext
    {
        public required INext? p_next;
        public required string p_label;
        public required TextureFormat p_format;
        public required Vec3<uint> p_size;
        public required SampleCount p_sampleCount;
        public required uint p_mipLevelCount;
        public required uint p_arrayLayers;
        public required TextureUsageFlags p_usage;

        public readonly INext? Next => p_next;
    }
}
