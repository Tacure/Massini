namespace Massini.Bindings.Vulkan
{
    public partial struct VkSubpassSampleLocationsEXT
    {
        [NativeTypeName("uint32_t")]
        public uint subpassIndex;

        public VkSampleLocationsInfoEXT sampleLocationsInfo;
    }
}
