namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkSurfacePresentModeCompatibilityEXT
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("uint32_t")]
        public uint presentModeCount;

        public VkPresentModeKHR* pPresentModes;
    }
}
