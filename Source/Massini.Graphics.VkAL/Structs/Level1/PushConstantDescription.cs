
using Massini.Graphics.VkAL.Enums;

namespace Massini.Graphics.VkAL.Structs.Level1
{
    public struct PushConstantDescription
    {
        public required ShaderStageFlags p_stage;
        public required uint p_size;
    }
}
