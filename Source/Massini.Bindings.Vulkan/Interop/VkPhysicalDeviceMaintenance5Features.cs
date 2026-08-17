namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceMaintenance5Features
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint maintenance5;
    }
}
