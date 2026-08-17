namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceVideoMaintenance1FeaturesKHR
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint videoMaintenance1;
    }
}
