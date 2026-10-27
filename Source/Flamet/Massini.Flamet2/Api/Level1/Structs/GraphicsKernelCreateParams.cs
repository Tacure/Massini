
using Massini.Flamet2.Api.Level1.Enums;
using Massini.Flamet2.Api.Level1.Interfaces;

namespace Massini.Flamet2.Api.Level1.Structs
{
    public struct GraphicsKernelCreateParams
    {
        public required ILayout1 p_layout;
        public required ShaderStage[] p_stages;
        public required PrimitiveTopology p_topology;
        public required TextureFormat[] p_colorAttachmentFormats;
        public required TextureFormat p_depthStencilAttachmentFormat;
    }   
}