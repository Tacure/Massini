using Massini.Coat.Enums;
using Massini.Coat.Interfaces;

namespace Massini.Coat.Structs.Level1
{
    public struct DeviceCreateParams : INext
    {
        public required INext? p_next;
        public required FeatureLevel p_featureLevel;
        public required AdapterFeatures p_features;

        public readonly INext? Next => p_next;
    }
}
