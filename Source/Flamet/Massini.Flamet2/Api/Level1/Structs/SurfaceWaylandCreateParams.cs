using Massini.Core.Interop.Linux;
using Massini.Flamet2.Api.Level1.Interfaces;

namespace Massini.Flamet2.Api.Level1.Structs
{
    public unsafe struct SurfaceWaylandCreateParams : INext
    {
        public required INext? p_next;
        public required WlDisplay* p_ptr_display;
        public required WlSurface* p_ptr_surface;
        
        public readonly INext? Next => p_next;
    }
}