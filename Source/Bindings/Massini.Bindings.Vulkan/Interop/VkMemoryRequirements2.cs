namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkMemoryRequirements2
    {
        public VkStructureType sType;

        public void* pNext;

        public VkMemoryRequirements memoryRequirements;
    }
}
