namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceTimelineSemaphoreProperties
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("uint64_t")]
        public ulong maxTimelineSemaphoreValueDifference;
    }
}
