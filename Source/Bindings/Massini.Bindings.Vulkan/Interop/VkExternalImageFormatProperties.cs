namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkExternalImageFormatProperties
    {
        public VkStructureType sType;

        public void* pNext;

        public VkExternalMemoryProperties externalMemoryProperties;
    }
}
