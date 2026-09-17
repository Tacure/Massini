namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkSurfaceFormat2KHR
    {
        public VkStructureType sType;

        public void* pNext;

        public VkSurfaceFormatKHR surfaceFormat;
    }
}
