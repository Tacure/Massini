namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkComputeOccupancyPriorityParametersNV
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public float occupancyPriority;

        public float occupancyThrottling;
    }
}
