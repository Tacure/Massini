namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceFragmentDensityMapOffsetPropertiesEXT
    {
        public VkStructureType sType;

        public void* pNext;

        public VkExtent2D fragmentDensityOffsetGranularity;
    }
}
