namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceVideoEncodeQuantizationMapFeaturesKHR
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint videoEncodeQuantizationMap;
    }
}
