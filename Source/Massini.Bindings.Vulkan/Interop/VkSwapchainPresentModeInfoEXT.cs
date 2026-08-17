namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkSwapchainPresentModeInfoEXT
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("uint32_t")]
        public uint swapchainCount;

        [NativeTypeName("const VkPresentModeKHR *")]
        public VkPresentModeKHR* pPresentModes;
    }
}
