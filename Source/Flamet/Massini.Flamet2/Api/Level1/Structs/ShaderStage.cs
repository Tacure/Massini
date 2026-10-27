using Massini.Flamet2.Api.Level1.Enums;

namespace Massini.Flamet2.Api.Level1.Structs
{
    public struct ShaderStage
    {
        public required ShaderStageFlags p_stage;
        public required byte[] p_code;
        public required string p_entryPoint;
    }
}