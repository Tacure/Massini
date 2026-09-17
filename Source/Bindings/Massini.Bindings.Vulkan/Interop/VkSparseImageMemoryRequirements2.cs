namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkSparseImageMemoryRequirements2
    {
        public VkStructureType sType;

        public void* pNext;

        public VkSparseImageMemoryRequirements memoryRequirements;
    }
}
