using Massini.Flamet.Enums;

namespace Massini.Flamet.Sugar.Classes.Reflection
{
    public class ShaderReflection
    {
        public required string EntryPoint { get; init; }
        public required ShaderStageFlags Stage { get; init; }
        public required SetReflection[] Sets { get; init; }
        public required PushConstantReflection? PushConstants { get; init; }
    }   
}
