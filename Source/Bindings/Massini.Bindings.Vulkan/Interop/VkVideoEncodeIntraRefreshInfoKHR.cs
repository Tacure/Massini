namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkVideoEncodeIntraRefreshInfoKHR
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("uint32_t")]
        public uint intraRefreshCycleDuration;

        [NativeTypeName("uint32_t")]
        public uint intraRefreshIndex;
    }
}
