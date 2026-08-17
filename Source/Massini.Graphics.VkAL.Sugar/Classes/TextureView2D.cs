using Massini.Graphics.VkAL.Classes;
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Structs.Level1;
using Massini.Graphics.VkAL.Sugar.Structs;

namespace Massini.Graphics.VkAL.Sugar.Classes
{
    public class TextureView2D : TextureView
    {
        public TextureView2D(Texture i_texture, in TypedTextureViewCreateParams i_createParams) : base(i_texture, new() 
        {
            p_next = i_createParams.p_next,
            p_label = i_createParams.p_label,
            p_format = i_createParams.p_format,
            p_mipLevelCount = i_createParams.p_mipLevelCount,
            p_sampleCount = i_createParams.p_sampleCount,
            p_aspect = i_createParams.p_aspect,
            p_baseMipLevel = i_createParams.p_baseMipLevel,
            p_type = TextureViewType.View2D,
            p_usage = i_createParams.p_usage,
            p_baseArrayLayer = i_createParams.p_baseArrayLayer,
            p_layerCount = i_createParams.p_layerCount,
        })
        {
        }
    }
}
