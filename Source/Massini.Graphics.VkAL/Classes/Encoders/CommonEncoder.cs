
using Massini.Graphics.VkAL.Classes.Commands;
using Massini.Graphics.VkAL.Structs.Level1;
using Massini.Graphics.VkAL.Structs.Level1.Commands;

namespace Massini.Graphics.VkAL.Classes.Encoders
{
    public class CommonEncoder : CommandEncoder
    {
        public void CmdBindShaderLink(ShaderLink i_shaderLink)
        {
            Push<CmdBindShaderLink>(cmd => { cmd.p_shaderLink = i_shaderLink; });
        }

        public void CmdBindSets(uint i_firstSet, Set[] i_pipelineSets)
        {
            Push<CmdBindSets>(cmd =>
            {
                cmd.p_firstSet = i_firstSet;
                cmd.p_pipelineSets = i_pipelineSets;
            });
        }

        public void CmdPushSet(uint i_set, SetEntryBinding[] i_bindingDescription) 
        {
            Push<CmdPushSet>(cmd =>
            {
                cmd.p_set = i_set;
                cmd.p_bindingDescription = i_bindingDescription;
            });
        }

        public unsafe void CmdPushConstant(PushContantCmdParams i_cmdParams)
        {
            byte[] data = new byte[i_cmdParams.p_size];
            fixed (byte* dstDataPtr = data)
            {
                System.Buffer.MemoryCopy(i_cmdParams.p_data, dstDataPtr, data.Length, data.Length);
            }
            Push<CmdPushConstant>(cmd =>
            {
                cmd.p_stageFlags = i_cmdParams.p_stageFlags;
                cmd.p_data = data;
            });
        }
    }
}