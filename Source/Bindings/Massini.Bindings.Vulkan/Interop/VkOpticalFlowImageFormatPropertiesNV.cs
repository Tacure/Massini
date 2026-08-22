namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkOpticalFlowImageFormatPropertiesNV
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public VkFormat format;
    }
}
