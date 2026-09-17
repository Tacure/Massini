namespace Massini.Bindings.Vulkan
{
    public partial struct VkDisplayModeParametersKHR
    {
        public VkExtent2D visibleRegion;

        [NativeTypeName("uint32_t")]
        public uint refreshRate;
    }
}
