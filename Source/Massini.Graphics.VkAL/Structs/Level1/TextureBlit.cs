
using Massini.Core.Math.Primitives;

namespace Massini.Graphics.VkAL.Structs.Level1
{
    public struct TextureBlit
    {
        public TextureSubresourceLayers p_srcSubresource;
        public Vec3<int> p_srcOffsetA;
        public Vec3<int> p_srcOffsetB;
        public TextureSubresourceLayers p_dstSubresource;
        public Vec3<int> p_dstOffsetA;
        public Vec3<int> p_dstOffsetB;
    }
}
