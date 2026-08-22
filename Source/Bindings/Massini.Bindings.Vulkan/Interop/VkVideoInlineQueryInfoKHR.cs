namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkVideoInlineQueryInfoKHR
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkQueryPool")]
        public VkQueryPool_T* queryPool;

        [NativeTypeName("uint32_t")]
        public uint firstQuery;

        [NativeTypeName("uint32_t")]
        public uint queryCount;
    }
}
