namespace Massini.Bindings.Vulkan
{
    public partial struct VkInputAttachmentAspectReference
    {
        [NativeTypeName("uint32_t")]
        public uint subpass;

        [NativeTypeName("uint32_t")]
        public uint inputAttachmentIndex;

        [NativeTypeName("VkImageAspectFlags")]
        public uint aspectMask;
    }
}
