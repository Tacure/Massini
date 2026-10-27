using Massini.Flamet2.Api.Level1.Enums;
using Massini.Flamet2.Api.Level1.Interfaces;

namespace Massini.Flamet2.Api.Level1.Structs
{
    public struct RenderPassDepthStencilAttachment
    {
        public required ITextureView1 p_textureView;
        public required float p_depthClearValue;
        public required LoadOp p_depthLoadOp;
        public required StoreOp p_depthStoreOp;
        public required bool p_depthReadOnly;
        public required uint p_stencilClearValue;
        public required LoadOp p_stencilLoadOp;
        public required StoreOp p_stencilStoreOp;
        public required bool p_stencilReadOnly;
    }
}
