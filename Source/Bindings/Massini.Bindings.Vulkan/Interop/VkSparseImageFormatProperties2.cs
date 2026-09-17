namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkSparseImageFormatProperties2
    {
        public VkStructureType sType;

        public void* pNext;

        public VkSparseImageFormatProperties properties;
    }
}
