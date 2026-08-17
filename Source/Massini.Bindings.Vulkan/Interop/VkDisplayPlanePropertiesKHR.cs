namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkDisplayPlanePropertiesKHR
    {
        [NativeTypeName("VkDisplayKHR")]
        public VkDisplayKHR_T* currentDisplay;

        [NativeTypeName("uint32_t")]
        public uint currentStackIndex;
    }
}
