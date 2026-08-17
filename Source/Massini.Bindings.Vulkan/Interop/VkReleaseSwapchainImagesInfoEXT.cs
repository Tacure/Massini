namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkReleaseSwapchainImagesInfoEXT
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkSwapchainKHR")]
        public VkSwapchainKHR_T* swapchain;

        [NativeTypeName("uint32_t")]
        public uint imageIndexCount;

        [NativeTypeName("const uint32_t *")]
        public uint* pImageIndices;
    }
}
