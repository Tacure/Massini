
using Massini.Graphics.VkAL.Classes.Commands;
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Structs.Level1;
using Massini.Graphics.VkAL.Structs.Level1.Commands;

namespace Massini.Graphics.VkAL.Classes.Encoders
{
    public sealed class RenderPassEncoder : CommonEncoder
    {
        public void CmdSetViewport(float i_x, float i_y, float i_width, float i_height, float i_minDepth, float i_maxDepth)
        {
            Push<CmdSetViewport>(cmd =>
            {
                cmd.p_x = i_x;
                cmd.p_y = i_y;
                cmd.p_width = i_width;
                cmd.p_height = i_height;
                cmd.p_minDepth = i_minDepth;
                cmd.p_maxDepth = i_maxDepth;
            });
        }

        public void CmdSetScissorRect(uint i_x, uint i_y, uint i_width, uint i_height)
        {
            Push<CmdSetScissorRect>(cmd =>
            {
                cmd.p_x = i_x;
                cmd.p_y = i_y;
                cmd.p_width = i_width;
                cmd.p_height = i_height;
            });
        }

        public void CmdBindIndexBuffer(Buffer i_buffer, IndexFormat i_indexFormat, ulong i_offset, ulong i_size)
        {
            Push<CmdBindIndexBuffer>(cmd =>
            {
                cmd.p_buffer = i_buffer;
                cmd.p_indexFormat = i_indexFormat;
                cmd.p_offset = i_offset;
                cmd.p_size = i_size;
            });
        }

        public void CmdBindVertexBuffer(Buffer i_buffer, uint i_firstBinding, ulong i_offset, ulong i_size)
        {
            Push<CmdBindVertexBuffer>(cmd =>
            {
                cmd.p_buffer = i_buffer;
                cmd.p_firstBinding = i_firstBinding;
                cmd.p_offset = i_offset;
                cmd.p_size = i_size;
            });
        }

        public void CmdDrawIndexed(uint i_indexCount, uint i_instanceCount, uint i_firstIndex, int i_vertexOffset, uint i_firstInstance)
        {
            Push<CmdDrawIndexed>(cmd =>
            {
                cmd.p_indexCount = i_indexCount;
                cmd.p_instanceCount = i_instanceCount;
                cmd.p_firstIndex = i_firstIndex;
                cmd.p_vertexOffset = i_vertexOffset;
                cmd.p_firstInstance = i_firstInstance;
            });
        }

        public void CmdDraw(uint i_vertexCount, uint i_instanceCount, uint i_firstVertex, uint i_firstInstance)
        {
            Push<CmdDraw>(cmd =>
            {
                cmd.p_vertexCount = i_vertexCount;
                cmd.p_instanceCount = i_instanceCount;
                cmd.p_firstVertex = i_firstVertex;
                cmd.p_firstInstance = i_firstInstance;
            });
        }

        public void CmdSetCullMode(CullMode i_cullMode)
        {
            Push<CmdSetCullMode>(cmd => { cmd.p_cullMode = i_cullMode; });
        }

        public void CmdSetRasterizerDiscardEnable(bool i_rasterizerDiscardEnable)
        {
            Push<CmdSetRasterizerDiscardEnable>(cmd => { cmd.p_rasterizerDiscardEnable = i_rasterizerDiscardEnable; });
        }

        public void CmdSetDepthTestEnable(bool i_depthTestEnable)
        {
            Push<CmdSetDepthTestEnable>(cmd => { cmd.p_depthTestEnable = i_depthTestEnable; });
        }

        public void CmdSetStencilTestEnable(bool i_stencilTestEnable)
        {
            Push<CmdSetStencilTestEnable>(cmd => { cmd.p_stencilTestEnable = i_stencilTestEnable; });
        }

        public void CmdSetDepthBiasEnable(bool i_depthBiasEnable)
        {
            Push<CmdSetDepthBiasEnable>(cmd => { cmd.p_depthBiasEnable = i_depthBiasEnable; });
        }

        public void CmdSetPolygonMode(PolygonMode i_polygonMode)
        {
            Push<CmdSetPolygonMode>(cmd => { cmd.p_polygonMode = i_polygonMode; });
        }

        public void CmdSetRasterizationSamples(SampleCount i_rasterizationSamples)
        {
            Push<CmdSetRasterizationSamples>(cmd => { cmd.p_rasterizationSamples = i_rasterizationSamples; });
        }

        public void CmdSetSampleMask(SampleCount i_samples, uint[] i_mask)
        {
            Push<CmdSetSampleMask>(cmd =>
            {
                cmd.p_samples = i_samples;
                cmd.p_mask = i_mask;
            });
        }

        public void CmdSetFrontFace(FrontFace i_frontFace)
        {
            Push<CmdSetFrontFace>(cmd => { cmd.p_frontFace = i_frontFace; });
        }

        public void CmdSetPrimitiveTopology(PrimitiveTopology i_primitiveTopology)
        {
            Push<CmdSetPrimitiveTopology>(cmd => { cmd.p_primitiveTopology = i_primitiveTopology; });
        }

        public void CmdSetPrimitiveRestartEnable(bool i_primitiveRestartEnable)
        {
            Push<CmdSetPrimitiveRestartEnable>(cmd => { cmd.p_primitiveRestartEnable = i_primitiveRestartEnable; });
        }

        public void CmdSetDepthClampEnable(bool i_depthClampEnable)
        {
            Push<CmdSetDepthClampEnable>(cmd => { cmd.p_depthClampEnable = i_depthClampEnable; });
        }

        public void CmdSetAlphaToCoverageEnable(bool i_alphaToCoverageEnable)
        {
            Push<CmdSetAlphaToCoverageEnable>(cmd => { cmd.p_alphaToCoverageEnable = i_alphaToCoverageEnable; });
        }

        public void CmdSetColorBlendEnable(uint i_firstAttachment, bool[] i_colorBlendEnable)
        {
            Push<CmdSetColorBlendEnable>(cmd => 
            { 
                cmd.p_firstAttachment = i_firstAttachment; 
                cmd.p_colorBlendEnable = i_colorBlendEnable; 
            });
        }

        public void CmdSetColorWriteMask(uint i_firstAttachment, ColorComponentFlags[] i_colorWriteMasks)
        {
            Push<CmdSetColorWriteMask>(cmd => 
            { 
                cmd.p_firstAttachment = i_firstAttachment; 
                cmd.p_colorWriteMasks = i_colorWriteMasks; 
            });
        }

        public void CmdSetVertexInput(VertexAttributesLayout[] i_vertexAttributesLayouts)
        {
            Push<CmdSetVertexInput>(cmd => { cmd.p_vertexAttributesLayouts = i_vertexAttributesLayouts; });
        }

        public void CmdSetColorBlendEquation(SetColorBlendEquationCmdParams i_cmdParams)
        {
            Push<CmdSetColorBlendEquation>(cmd => 
            { 
                cmd.p_firstAttachment = i_cmdParams.p_firstAttachment; 
                cmd.p_blendEquations = i_cmdParams.p_blendEquations; 
            });
        }

        public void CmdSetDepthCompareOp(CompareOp i_depthCompareOp)
        {
            Push<CmdSetDepthCompareOp>(cmd => { cmd.p_depthCompareOp = i_depthCompareOp; });
        }

        public void CmdSetDepthWriteEnable(bool i_depthWriteEnable)
        {
            Push<CmdSetDepthWriteEnable>(cmd => { cmd.p_depthWriteEnable = i_depthWriteEnable; });
        }

        public void CmdSetLineWidth(float i_lineWidth)
        {
            Push<CmdSetLineWidth>(cmd => { cmd.p_lineWidth = i_lineWidth; });
        }
    }
}
