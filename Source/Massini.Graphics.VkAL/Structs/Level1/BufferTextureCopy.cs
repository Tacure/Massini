
using Massini.Core.Math.Primitives;

namespace Massini.Graphics.VkAL.Structs.Level1
{
    public struct BufferTextureCopy
    {
        public required ulong p_bufferOffset;
        public required uint p_bufferRowLengthInTexels;
        public required uint p_bufferTextureHeightInTexels;
        public required TextureSubresourceLayers p_textureSubresource;
        public required Vec3<int> p_textureOffset;
        public required Vec3<uint> p_textureExtent;
    }
}
