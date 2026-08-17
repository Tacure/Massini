namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceFeatures2
    {
        public VkStructureType sType;

        public void* pNext;

        public VkPhysicalDeviceFeatures features;
    }
}
