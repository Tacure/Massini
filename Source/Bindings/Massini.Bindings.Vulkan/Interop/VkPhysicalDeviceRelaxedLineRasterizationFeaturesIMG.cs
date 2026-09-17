namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceRelaxedLineRasterizationFeaturesIMG
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint relaxedLineRasterization;
    }
}
