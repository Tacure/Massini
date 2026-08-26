
using Massini.Coat.Interfaces;
using Massini.Coat.Structs.Level1;

namespace Massini.Coat.Sugar.Structs
{
    public struct SmartShaderLinkCreateParams : INext
    {
        public INext? p_next;
        public string p_label;
        public ShaderLinkStage[] p_stages;

        public readonly INext? Next => p_next;
    }
}
