namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDevicePrivateDataFeatures
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint privateData;
    }
}
