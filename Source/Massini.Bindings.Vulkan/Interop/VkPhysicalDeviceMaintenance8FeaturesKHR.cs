namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceMaintenance8FeaturesKHR
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint maintenance8;
    }
}
