namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkImageSubresource2
    {
        public VkStructureType sType;

        public void* pNext;

        public VkImageSubresource imageSubresource;
    }
}
