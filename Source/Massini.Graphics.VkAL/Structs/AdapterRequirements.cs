
using Massini.Graphics.VkAL.Interfaces;

namespace Massini.Graphics.VkAL.Structs
{
    public struct AdapterRequirements : INext
    {
        public required INext? p_next;

        public readonly INext? Next => p_next;
    }
}
