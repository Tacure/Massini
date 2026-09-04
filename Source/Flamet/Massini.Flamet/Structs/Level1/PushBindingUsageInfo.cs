using Massini.Flamet.Enums;
using Massini.Flamet.Interfaces;

namespace Massini.Flamet.Structs.Level1
{
    public struct PushBindingUsageInfo : INext
    {
        public required INext? p_next;
        public required EntryMode p_mode;
        public required ShaderStageFlags p_stages;

        public readonly INext? Next => p_next;
    }
}
