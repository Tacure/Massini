using Massini.Graphics.VkAL.Classes;
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Sugar.Structs;

namespace Massini.Graphics.VkAL.Sugar.Classes
{
    public class Texture2D : Texture
    {
        public Texture2D(Device i_device, in TypedTextureCreateParams i_createParams) : base(i_device, new()
        {
            p_next = i_createParams.p_next,
            p_label = i_createParams.p_label,
            p_format = i_createParams.p_format,
            p_mipLevelCount = i_createParams.p_mipLevelCount,
            p_sampleCount = i_createParams.p_sampleCount,
            p_size = i_createParams.p_size,
            p_type = TextureType.Texture2D,
            p_usage = i_createParams.p_usage,
            p_arrayLayers = i_createParams.p_arrayLayers,
        })
        {
        }

        public TextureView2D CreateView2D(in TypedTextureViewCreateParams i_createParams)
        {
            return new TextureView2D(this, i_createParams);
        }
    }
}
