
using Massini.Graphics.VkAL.Interfaces;

namespace Massini.Graphics.VkAL.Structs
{
    public struct InstanceCreateParams : INext
    {
        public required INext? p_next;
        public required string p_label;
        public required InstanceFeatures p_features;

        public readonly INext? Next => p_next;
    }
}
