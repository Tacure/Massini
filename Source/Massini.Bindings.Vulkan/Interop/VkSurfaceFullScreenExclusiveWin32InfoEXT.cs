namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkSurfaceFullScreenExclusiveWin32InfoEXT
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("HMONITOR")]
        public HMONITOR__* hmonitor;
    }
}
