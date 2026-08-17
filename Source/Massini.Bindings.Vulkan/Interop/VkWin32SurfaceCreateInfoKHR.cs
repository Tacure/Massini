namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkWin32SurfaceCreateInfoKHR
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkWin32SurfaceCreateFlagsKHR")]
        public uint flags;

        [NativeTypeName("HINSTANCE")]
        public HINSTANCE__* hinstance;

        [NativeTypeName("HWND")]
        public HWND__* hwnd;
    }
}
