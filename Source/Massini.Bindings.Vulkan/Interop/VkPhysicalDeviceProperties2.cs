namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceProperties2
    {
        public VkStructureType sType;

        public void* pNext;

        public VkPhysicalDeviceProperties properties;
    }
}
