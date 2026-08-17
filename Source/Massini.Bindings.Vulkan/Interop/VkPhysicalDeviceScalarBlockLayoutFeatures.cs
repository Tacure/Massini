namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceScalarBlockLayoutFeatures
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint scalarBlockLayout;
    }
}
