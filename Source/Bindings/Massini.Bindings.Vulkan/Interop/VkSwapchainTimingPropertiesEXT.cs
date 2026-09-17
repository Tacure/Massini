namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkSwapchainTimingPropertiesEXT
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("uint64_t")]
        public ulong refreshDuration;

        [NativeTypeName("uint64_t")]
        public ulong refreshInterval;
    }
}
