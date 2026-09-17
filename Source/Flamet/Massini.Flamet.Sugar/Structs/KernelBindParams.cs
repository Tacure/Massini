using Massini.Flamet.Interfaces;

namespace Massini.Flamet.Sugar.Structs
{
    public struct KernelBindParams : INext
    {
        public INext? p_next;
        public KernelBindParam[] p_params;

        public readonly INext? Next => p_next;
    }
}