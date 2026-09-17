namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkImageDescriptorInfoEXT
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("const VkImageViewCreateInfo *")]
        public VkImageViewCreateInfo* pView;

        public VkImageLayout layout;
    }
}
