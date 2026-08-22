namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkImageViewUsageCreateInfo
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkImageUsageFlags")]
        public uint usage;
    }
}
