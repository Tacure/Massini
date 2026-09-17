namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkSubresourceLayout2
    {
        public VkStructureType sType;

        public void* pNext;

        public VkSubresourceLayout subresourceLayout;
    }
}
