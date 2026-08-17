
using Massini.Graphics.VkAL.Enums;

namespace Massini.Graphics.VkAL.Structs
{
    public struct AdapterInfo
    {
        public required string p_name;
        public required uint p_apiVersion;
        public required uint p_driverVersion;
        public required uint p_vendorID;
        public required uint p_deviceID;
        public required AdapterType p_type;
        public required FeatureLevel p_featureLevel;
        public required AdapterFeatures p_features;
    }
}
