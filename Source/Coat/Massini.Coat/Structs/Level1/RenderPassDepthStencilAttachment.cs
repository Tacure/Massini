
using Massini.Coat.Classes;
using Massini.Coat.Enums;
using Massini.Coat.Interfaces;

namespace Massini.Coat.Structs.Level1
{
    public struct RenderPassDepthStencilAttachment : INext
    {
        public required INext? p_next;
        public required TextureView p_textureView;
        public required float p_depthClearValue;
        public required LoadOp p_depthLoadOp;
        public required StoreOp p_depthStoreOp;
        public required bool p_depthReadOnly;
        public required uint p_stencilClearValue;
        public required LoadOp p_stencilLoadOp;
        public required StoreOp p_stencilStoreOp;
        public required bool p_stencilReadOnly;

        public readonly INext? Next => p_next;
    }
}
