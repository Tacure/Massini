namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkSharedPresentSurfaceCapabilitiesKHR
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkImageUsageFlags")]
        public uint sharedPresentSupportedUsageFlags;
    }
}
