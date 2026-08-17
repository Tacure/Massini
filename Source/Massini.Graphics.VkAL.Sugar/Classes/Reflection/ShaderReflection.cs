
using Massini.Graphics.VkAL.Enums;

namespace Massini.Graphics.VkAL.Sugar.Classes.Reflection
{
    public class ShaderReflection
    {
        public required string EntryPoint { get; init; }
        public required ShaderStageFlags Stage { get; init; }
        public required SetReflection[] Sets { get; init; }
        public required PushConstantReflection? PushConstants { get; init; }
    }   
}
