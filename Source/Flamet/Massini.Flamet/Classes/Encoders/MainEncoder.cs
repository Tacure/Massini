
using Massini.Flamet.Classes;
using Massini.Flamet.Classes.Encoders;
using Massini.Flamet.Classes.Commands;
using Massini.Flamet.Enums;
using Massini.Flamet.Structs.Level1;
using Buffer = Massini.Flamet.Classes.Buffer;

namespace Massini.Flamet.Classes.Encoders
{
    public sealed class MainEncoder : CommandEncoder
    {
        public RenderPassEncoder CmdRenderPass(RenderPassBeginParams i_beginParams) 
        {
            return PushWithEncoder<RenderPassEncoder, CmdRenderPass>((encoder, cmd) =>
            {
                cmd.p_encoder = encoder;
                cmd.p_beginParams = i_beginParams;
            });
        }

        public ComputePassEncoder CmdComputePass(ComputePassBeginParams i_beginParams) 
        {
            return PushWithEncoder<ComputePassEncoder, CmdComputePass>((encoder, cmd) =>
            {
                cmd.p_encoder = encoder;
                cmd.p_beginParams = i_beginParams;
            });
        }

        public void CmdCopyBufferToBuffer(Buffer i_srcBuffer, Buffer i_dstBuffer, BufferCopy[] i_bufferCopies) 
        {
            Push<CmdCopyBufferToBuffer>(cmd => 
            {
                cmd.p_srcBuffer = i_srcBuffer;
                cmd.p_dstBuffer = i_dstBuffer;
                cmd.p_bufferCopies = i_bufferCopies;
            });
        }

        public void CmdCopyBufferToTexture(Buffer i_srcBuffer, Texture i_dstTexture, BufferTextureCopy[] i_regions)
        {
            Push<CmdCopyBufferToTexture>(cmd =>
            {
                cmd.p_srcBuffer = i_srcBuffer;
                cmd.p_dstTexture = i_dstTexture;
                cmd.p_regions = i_regions;
            });
        }

        public void CmdCopyTextureToBuffer(Texture i_srcTexture, Buffer i_dstBuffer, BufferTextureCopy[] i_regions) 
        {
            Push<CmdCopyTextureToBuffer>(cmd => 
            {
                cmd.p_srcTexture = i_srcTexture;
                cmd.p_dstBuffer = i_dstBuffer;
                cmd.p_regions = i_regions;
            });
        }

        public void CmdCopyTextureToTexture(Texture i_srcTexture, Texture i_dstTexture, TextureCopy[] i_regions) 
        {
            Push<CmdCopyTextureToTexture>(cmd => 
            {
                cmd.p_srcTexture = i_srcTexture;
                cmd.p_dstTexture = i_dstTexture;
                cmd.p_regions = i_regions;
            });
        }

        public void CmdBlitTexture(Texture i_srcTexture, Texture i_dstTexture, TextureBlit[] i_regions, FilterMode i_filterMode) 
        {
            Push<CmdBlitTexture>(cmd => 
            {
                cmd.p_srcTexture = i_srcTexture;
                cmd.p_dstTexture = i_dstTexture;
                cmd.p_regions = i_regions;
                cmd.p_filterMode = i_filterMode;
            });
        }
    }
}
