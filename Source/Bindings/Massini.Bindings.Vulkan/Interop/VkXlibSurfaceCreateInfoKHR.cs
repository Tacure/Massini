namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkXlibSurfaceCreateInfoKHR
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkWin32SurfaceCreateFlagsKHR")]
        public uint flags;

        [NativeTypeName("HINSTANCE")]
        public void* dpy;

        [NativeTypeName("HWND")]
        public nint window;
    }
}
