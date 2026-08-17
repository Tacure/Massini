namespace Massini.Bindings.Vulkan
{
    public partial struct VkClearAttachment
    {
        [NativeTypeName("VkImageAspectFlags")]
        public uint aspectMask;

        [NativeTypeName("uint32_t")]
        public uint colorAttachment;

        public VkClearValue clearValue;
    }
}
