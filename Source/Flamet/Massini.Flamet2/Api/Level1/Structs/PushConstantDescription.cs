using Massini.Flamet2.Api.Level1.Enums;

namespace Massini.Flamet2.Api.Level1.Structs
{
    public struct PushConstantDescription
    {
        public required ShaderStageFlags p_stage;
        public required uint p_size;
    }
}
