
using Massini.Coat.Interfaces;

namespace Massini.Coat.Structs.Level1
{
    public struct CommandListBeginParams : INext
    {
        public required INext? p_next;

        public readonly INext? Next => p_next;
    }
}
