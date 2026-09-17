
using Massini.Flamet.Classes;
using Massini.Flamet.Interfaces;

namespace Massini.Flamet.Structs.Level1
{
    public struct PipelineCreateParams : INext
    {
        public required INext? p_next;
        public required Layout p_layout;
        public required ShaderStage[] p_stages;

        public readonly INext? Next => p_next;
    }
}