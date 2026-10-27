using Massini.Core.Math.Primitives;
using Massini.Flamet2.Api.Level1.Enums;
using Massini.Flamet2.Api.Level1.Interfaces;

namespace Massini.Flamet2.Api.Level1.Structs
{
    public struct RenderPassColorAttachment
    {
        public required ITextureView1 p_textureView;
        public required uint p_depthSlice;
        public required LoadOp p_loadOp;
        public required StoreOp p_storeOp;
        public required Vec4<float> p_clearColor;
    }
}
