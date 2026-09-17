namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceSwapchainMaintenance1FeaturesKHR
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint swapchainMaintenance1;
    }
}
