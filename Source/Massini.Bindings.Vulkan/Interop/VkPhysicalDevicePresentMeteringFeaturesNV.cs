namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDevicePresentMeteringFeaturesNV
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint presentMetering;
    }
}
