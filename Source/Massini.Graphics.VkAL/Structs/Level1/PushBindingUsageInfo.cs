
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Interfaces;

namespace Massini.Graphics.VkAL.Structs.Level1
{
    public struct PushBindingUsageInfo : INext
    {
        public required INext? p_next;
        public required EntryMode p_mode;
        public required ShaderStageFlags p_stages;

        public readonly INext? Next => p_next;
    }
}
