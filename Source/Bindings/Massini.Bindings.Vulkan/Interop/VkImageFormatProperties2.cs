namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkImageFormatProperties2
    {
        public VkStructureType sType;

        public void* pNext;

        public VkImageFormatProperties imageFormatProperties;
    }
}
