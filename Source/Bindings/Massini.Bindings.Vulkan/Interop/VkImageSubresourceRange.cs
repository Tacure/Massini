namespace Massini.Bindings.Vulkan
{
    public partial struct VkImageSubresourceRange
    {
        [NativeTypeName("VkImageAspectFlags")]
        public uint aspectMask;

        [NativeTypeName("uint32_t")]
        public uint baseMipLevel;

        [NativeTypeName("uint32_t")]
        public uint levelCount;

        [NativeTypeName("uint32_t")]
        public uint baseArrayLayer;

        [NativeTypeName("uint32_t")]
        public uint layerCount;
    }
}
