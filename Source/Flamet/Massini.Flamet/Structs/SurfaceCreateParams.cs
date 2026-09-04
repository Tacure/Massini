
using Massini.Flamet.Classes;
using Massini.Flamet.Enums;
using Massini.Flamet.Interfaces;

namespace Massini.Flamet.Structs
{
    public struct SurfaceCreateParams : INext
    {
        public required INext? p_next;
        public required string p_label;

        public readonly INext? Next => p_next;
    }
}
