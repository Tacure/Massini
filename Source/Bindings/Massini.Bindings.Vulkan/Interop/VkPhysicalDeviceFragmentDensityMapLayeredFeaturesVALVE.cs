namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceFragmentDensityMapLayeredFeaturesVALVE
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint fragmentDensityMapLayered;
    }
}
