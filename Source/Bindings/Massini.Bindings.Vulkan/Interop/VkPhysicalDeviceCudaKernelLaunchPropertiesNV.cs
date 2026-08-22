namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceCudaKernelLaunchPropertiesNV
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("uint32_t")]
        public uint computeCapabilityMinor;

        [NativeTypeName("uint32_t")]
        public uint computeCapabilityMajor;
    }
}
