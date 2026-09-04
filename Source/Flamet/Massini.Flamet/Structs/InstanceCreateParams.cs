using Massini.Flamet.Interfaces;

namespace Massini.Flamet.Structs
{
    public struct InstanceCreateParams : INext
    {
        public required INext? p_next;
        public required string p_label;
        public required InstanceFeatures p_features;

        public readonly INext? Next => p_next;
    }
}
