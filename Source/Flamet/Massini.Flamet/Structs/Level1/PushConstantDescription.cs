using Massini.Flamet.Enums;

namespace Massini.Flamet.Structs.Level1
{
    public struct PushConstantDescription
    {
        public required ShaderStageFlags p_stage;
        public required uint p_size;
    }
}
