using System;
using Massini.Coat.Interfaces;
using Massini.Core.Interop.Linux;

namespace Massini.Coat.Structs
{
    public unsafe struct SurfaceXlibCreateParams : INext
    {
        public INext? p_next;
        public required XDisplay* p_ptr_display;
        public required nint p_window;

        public readonly INext? Next => p_next;
    }
}