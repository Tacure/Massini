
using Massini.Flamet.Enums;
using Massini.Flamet.Interfaces;

namespace Massini.Flamet.Sugar.Structs
{
    public struct GraphicsKernelBindConfig : INext
    {
        public required INext? p_next;
        public required CullMode p_cullMode;
        public required PolygonMode p_polygonMode;
        public required FrontFace p_frontFace;
        public required PrimitiveTopology p_primitiveTopology;
        public required bool p_primitiveRestartEnable;
        public required bool p_rasterizerDiscardEnable;
        public required SampleCount p_rasterizationSamples;
        public required float p_lineWidth;
        public required bool p_depthTestEnable;
        public required bool p_depthBiasEnable;
        public required bool p_depthClampEnable;
        public required CompareOp p_depthCompareOp;
        public required bool p_stencilTestEnable;
        public required bool p_alphaToCoverageEnable;

        public readonly INext? Next => p_next;
    }
}