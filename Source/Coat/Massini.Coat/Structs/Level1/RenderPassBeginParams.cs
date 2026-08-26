
using Massini.Coat.Interfaces;

namespace Massini.Coat.Structs.Level1
{
    public struct RenderPassBeginParams : INext
    {
        public required INext? p_next;
        public required RenderPassColorAttachment[] p_colorAttachments;
        public required RenderPassDepthStencilAttachment? p_depthStencilAttachment;

        public readonly INext? Next => p_next;
    }
}
