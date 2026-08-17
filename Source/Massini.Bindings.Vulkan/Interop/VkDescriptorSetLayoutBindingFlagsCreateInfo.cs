namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkDescriptorSetLayoutBindingFlagsCreateInfo
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("uint32_t")]
        public uint bindingCount;

        [NativeTypeName("const VkDescriptorBindingFlags *")]
        public uint* pBindingFlags;
    }
}
