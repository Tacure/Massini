namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkD3D12FenceSubmitInfoKHR
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("uint32_t")]
        public uint waitSemaphoreValuesCount;

        [NativeTypeName("const uint64_t *")]
        public ulong* pWaitSemaphoreValues;

        [NativeTypeName("uint32_t")]
        public uint signalSemaphoreValuesCount;

        [NativeTypeName("const uint64_t *")]
        public ulong* pSignalSemaphoreValues;
    }
}
