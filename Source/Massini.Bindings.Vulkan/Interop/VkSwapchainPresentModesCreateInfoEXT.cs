namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkSwapchainPresentModesCreateInfoEXT
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("uint32_t")]
        public uint presentModeCount;

        [NativeTypeName("const VkPresentModeKHR *")]
        public VkPresentModeKHR* pPresentModes;
    }
}
