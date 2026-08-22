
using Massini.Graphics.VkAL.Interfaces;
using Massini.Core.Interop.Windows;

namespace Massini.Graphics.VkAL.Structs
{
    public unsafe struct SurfaceWindowsCreateParams : INext
    {
        public required INext? p_next;
        public required Hwnd* p_ptr_hwnd;
        public required HInstance* p_ptr_hinstance;

        public readonly INext? Next => p_next;
    }
}
