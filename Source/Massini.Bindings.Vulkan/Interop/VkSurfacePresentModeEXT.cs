namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkSurfacePresentModeEXT
    {
        public VkStructureType sType;

        public void* pNext;

        public VkPresentModeKHR presentMode;
    }
}
