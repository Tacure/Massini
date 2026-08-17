
using Massini.Graphics.VkAL.Interfaces;

namespace Massini.Graphics.VkAL.Structs.Level1
{
    public struct CommandListBeginParams : INext
    {
        public required INext? p_next;

        public readonly INext? Next => p_next;
    }
}
