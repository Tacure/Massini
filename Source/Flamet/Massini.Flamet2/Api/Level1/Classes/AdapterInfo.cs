
using Massini.Flamet2.Api.Level1.Enums;

namespace Massini.Flamet2.Api.Level1.Classes
{
    public sealed class AdapterInfo
    {
        public required string Name { get; init; }
        public required uint ApiVersion { get; init; }
        public required uint DriverVersion { get; init; }
        public required uint VendorId { get; init; }
        public required uint DeviceId { get; init; }
        public required AdapterType AdapterType { get; init; }
        public required FeatureLevel FeatureLevel { get; init; }
        public required AdapterFeatures Features { get; init; }
    }
}
