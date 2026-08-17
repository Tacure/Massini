namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceCopyMemoryIndirectPropertiesNV
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkQueueFlags")]
        public uint supportedQueues;
    }
}
