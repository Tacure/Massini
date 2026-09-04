using Massini.Core.Interop.Linux;
using Massini.Flamet.Interfaces;

namespace Massini.Flamet.Structs
{
    public unsafe struct SurfaceWaylandCreateParams : INext
    {
        public INext? p_next;
        public required WlDisplay* p_ptr_display;
        public required WlSurface* p_ptr_surface;

        public readonly INext? Next => p_next;
    }
}