using Massini.Graphics.VkAL.Classes;
using Massini.Graphics.Color;
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Interfaces;

namespace Massini.Graphics.VkAL.Structs.Level1
{
    public struct RenderPassColorAttachment : INext
    {
        public required INext? p_next;
        public required TextureView p_textureView;
        public required uint p_depthSlice;
        public required LoadOp p_loadOp;
        public required StoreOp p_storeOp;
        public required Rgba<float> p_clearColor;

        public readonly INext? Next => p_next;
    }
}
