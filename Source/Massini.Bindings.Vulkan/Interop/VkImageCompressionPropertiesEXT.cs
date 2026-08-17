namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkImageCompressionPropertiesEXT
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkImageCompressionFlagsEXT")]
        public uint imageCompressionFlags;

        [NativeTypeName("VkImageCompressionFixedRateFlagsEXT")]
        public uint imageCompressionFixedRateFlags;
    }
}
