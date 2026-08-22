namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceVideoEncodeQualityLevelInfoKHR
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("const VkVideoProfileInfoKHR *")]
        public VkVideoProfileInfoKHR* pVideoProfile;

        [NativeTypeName("uint32_t")]
        public uint qualityLevel;
    }
}
