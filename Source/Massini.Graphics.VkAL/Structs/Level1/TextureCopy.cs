
using Massini.Core.Math.Primitives;

namespace Massini.Graphics.VkAL.Structs.Level1
{
    public struct TextureCopy
    {
        public required TextureSubresourceLayers p_srcSubresource;
        public required Vec3<int> p_srcOffset;
        public required TextureSubresourceLayers p_dstSubresource;
        public required Vec3<int> p_dstOffset;
        public required Vec3<uint> p_extent;
    }
}
