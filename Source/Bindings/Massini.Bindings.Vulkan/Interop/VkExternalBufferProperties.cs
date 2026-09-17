namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkExternalBufferProperties
    {
        public VkStructureType sType;

        public void* pNext;

        public VkExternalMemoryProperties externalMemoryProperties;
    }
}
