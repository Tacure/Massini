namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkFormatProperties2
    {
        public VkStructureType sType;

        public void* pNext;

        public VkFormatProperties formatProperties;
    }
}
