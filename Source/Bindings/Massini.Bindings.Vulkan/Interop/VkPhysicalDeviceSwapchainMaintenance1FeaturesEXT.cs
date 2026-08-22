namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceSwapchainMaintenance1FeaturesEXT
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint swapchainMaintenance1;
    }
}
