using Massini.Graphics.VkAL.Classes.Encoders;
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Structs.Level1.Commands;
using Massini.Graphics.VkAL.Sugar.Classes;
using Massini.Graphics.VkAL.Sugar.Structs;

namespace Massini.Graphics.VkAL.Sugar.Extensions
{
    public static class CommonEncoderExtensions
    {
        extension(CommonEncoder i_encoder)
        {
            public void CmdBindSmartShaderLink(SmartShaderLink i_smartShaderLink, SmartShaderLinkParams i_params)
            {
                i_smartShaderLink.Bind(i_encoder, i_params);
            }

            public unsafe void CmdPushConstant<T>(ShaderStageFlags i_stageFlags, T i_data)
                where T : unmanaged
            {
                i_encoder.CmdPushConstant(new PushContantCmdParams
                {
                    p_stageFlags = i_stageFlags,
                    p_data = &i_data,
                    p_size = (uint)sizeof(T)
                });
            }
        }
    }
}