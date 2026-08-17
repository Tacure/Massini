namespace Massini.Bindings.Vulkan
{
    public partial struct VkAttachmentSampleLocationsEXT
    {
        [NativeTypeName("uint32_t")]
        public uint attachmentIndex;

        public VkSampleLocationsInfoEXT sampleLocationsInfo;
    }
}
