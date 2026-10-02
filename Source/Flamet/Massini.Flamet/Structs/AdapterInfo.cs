using Massini.Flamet.Enums;

namespace Massini.Flamet.Structs
{
    public sealed class AdapterInfo
    {
        public string Name { get; init; }
        public uint ApiVersion { get; init; }
        public uint DriverVersion { get; init; }
        public uint VendorId { get; init; }
        public uint DeviceId { get; init; }
        public AdapterType Type { get; init; }
        public FeatureLevel Level { get; init; }
        public AdapterFeatures Features { get; init; }
    }
}
