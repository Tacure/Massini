namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceCudaKernelLaunchFeaturesNV
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint cudaKernelLaunchFeatures;
    }
}
