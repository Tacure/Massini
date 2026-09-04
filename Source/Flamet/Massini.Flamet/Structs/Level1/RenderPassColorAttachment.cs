using Massini.Core.Math.Primitives;
using Massini.Flamet.Classes;
using Massini.Flamet.Enums;
using Massini.Flamet.Interfaces;

namespace Massini.Flamet.Structs.Level1
{
    public struct RenderPassColorAttachment : INext
    {
        public required INext? p_next;
        public required TextureView p_textureView;
        public required uint p_depthSlice;
        public required LoadOp p_loadOp;
        public required StoreOp p_storeOp;
        public required Vec4<float> p_clearColor;

        public readonly INext? Next => p_next;
    }
}
