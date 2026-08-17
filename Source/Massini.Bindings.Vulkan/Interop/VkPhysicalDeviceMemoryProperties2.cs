namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceMemoryProperties2
    {
        public VkStructureType sType;

        public void* pNext;

        public VkPhysicalDeviceMemoryProperties memoryProperties;
    }
}
