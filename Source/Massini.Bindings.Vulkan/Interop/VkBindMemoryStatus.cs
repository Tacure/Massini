namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkBindMemoryStatus
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public VkResult* pResult;
    }
}
