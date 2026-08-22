namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceDescriptorSetHostMappingFeaturesVALVE
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint descriptorSetHostMapping;
    }
}
