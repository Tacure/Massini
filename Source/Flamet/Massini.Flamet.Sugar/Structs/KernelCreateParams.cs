using Massini.Flamet.Interfaces;
using Massini.Flamet.Structs.Level1;

namespace Massini.Flamet.Sugar.Structs
{
    public struct KernelCreateParams : INext
    {
        public INext? p_next;
        public string p_label;
        public ShaderStage[] p_stages;

        public readonly INext? Next => p_next;
    }
}
