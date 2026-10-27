
namespace Massini.Flamet2.Api.Level1.Structs
{
    public struct RenderPassBeginParams
    {
        public required RenderPassColorAttachment[] p_colorAttachments;
        public required RenderPassDepthStencilAttachment? p_depthStencilAttachment;
    }   
}