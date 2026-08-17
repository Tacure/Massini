namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDevicePerformanceQueryFeaturesKHR
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint performanceCounterQueryPools;

        [NativeTypeName("VkBool32")]
        public uint performanceCounterMultipleQueryPools;
    }
}
