
using Massini.Graphics.VkAL.Enums;

namespace Massini.Graphics.VkAL.Sugar.Classes.Reflection
{
    public class PushConstantReflection
    {
        public required string Name { get; init; }
        public required uint Size { get; init; }
        public required ShaderStageFlags StageFlags { get; set; }
    }   
}
