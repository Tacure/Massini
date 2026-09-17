namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkSubsampledImageFormatPropertiesEXT
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("uint32_t")]
        public uint subsampledImageDescriptorCount;
    }
}
