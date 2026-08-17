namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceSamplerFilterMinmaxProperties
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint filterMinmaxSingleComponentFormats;

        [NativeTypeName("VkBool32")]
        public uint filterMinmaxImageComponentMapping;
    }
}
