namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkWaylandSurfaceCreateInfoKHR
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkWin32SurfaceCreateFlagsKHR")]
        public uint flags;

        [NativeTypeName("HINSTANCE")]
        public void* display;

        [NativeTypeName("HWND")]
        public void* surface;
    }
}
