using System;
using Massini.Graphics.VkAL.Interfaces;
using Massini.Interop.Linux;

namespace Massini.Graphics.VkAL.Structs
{
    public unsafe struct SurfaceXlibCreateParams : INext
    {
        public INext? p_next;
        public required XDisplay* p_ptr_display;
        public required nint p_window;

        public readonly INext? Next => p_next;
    }
}