
using Massini.Coat.Classes;
using Massini.Coat.Enums;
using Massini.Coat.Interfaces;

namespace Massini.Coat.Structs
{
    public struct SurfaceCreateParams : INext
    {
        public required INext? p_next;
        public required string p_label;

        public readonly INext? Next => p_next;
    }
}
