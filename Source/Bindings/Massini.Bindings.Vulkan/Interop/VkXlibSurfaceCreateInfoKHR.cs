namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkXlibSurfaceCreateInfoKHR
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkXlibSurfaceCreateFlagsKHR")]
        public uint flags;

        [NativeTypeName("Display *")]
        public _XDisplay* dpy;

        [NativeTypeName("Window")]
        public nuint window;
    }
}
