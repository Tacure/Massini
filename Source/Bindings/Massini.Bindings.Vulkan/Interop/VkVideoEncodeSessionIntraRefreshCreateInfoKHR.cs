namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkVideoEncodeSessionIntraRefreshCreateInfoKHR
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public VkVideoEncodeIntraRefreshModeFlagBitsKHR intraRefreshMode;
    }
}
