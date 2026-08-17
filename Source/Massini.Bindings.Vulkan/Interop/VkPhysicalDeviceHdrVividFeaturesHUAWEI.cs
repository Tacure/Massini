namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceHdrVividFeaturesHUAWEI
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint hdrVivid;
    }
}
