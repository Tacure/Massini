namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceSurfaceInfo2KHR
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkSurfaceKHR")]
        public VkSurfaceKHR_T* surface;
    }
}
