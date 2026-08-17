
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Interfaces;

namespace Massini.Graphics.VkAL.Structs.Level1
{
    public struct SamplerCreateParams : INext
    {
        public required INext? p_next;
        public required string p_label;
        public required SamplerAdressMode p_addressModeU;
        public required SamplerAdressMode p_addressModeV;
        public required SamplerAdressMode p_addressModeW;
        public required FilterMode p_magFilter;
        public required FilterMode p_minFilter;
        public required CompareOp p_compareOperation;
        public required FilterMode p_mipmapFilter;
        public required float p_lodMaxClamp;
        public required float p_lodMinClamp;
        public required bool p_enableAnisotropy;
        public required ushort p_maxAnisotropy;
        public required float p_mipLodBias;
        public required bool p_enableUnnormalizedCoordinates;

        public readonly INext? Next => p_next;
    }
}
