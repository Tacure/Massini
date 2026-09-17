namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkTexelBufferDescriptorInfoEXT
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public VkFormat format;

        public VkDeviceAddressRangeEXT addressRange;
    }
}
