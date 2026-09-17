
using Massini.Flamet.Enums;
using Massini.Flamet.Interfaces;

namespace Massini.Flamet.Structs.Level1
{
    public struct GraphicsPipelineCreateParams : INext
    {
        public required INext? p_next;
        public required PrimitiveTopology p_topology;
        public required TextureFormat[] p_colorAttachmentFormats;
        public required TextureFormat p_depthStencilAttachmentFormat;

        public readonly INext? Next => p_next;
    }   
}