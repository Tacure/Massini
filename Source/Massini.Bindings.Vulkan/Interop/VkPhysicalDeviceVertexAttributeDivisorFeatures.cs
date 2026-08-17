namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceVertexAttributeDivisorFeatures
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint vertexAttributeInstanceRateDivisor;

        [NativeTypeName("VkBool32")]
        public uint vertexAttributeInstanceRateZeroDivisor;
    }
}
