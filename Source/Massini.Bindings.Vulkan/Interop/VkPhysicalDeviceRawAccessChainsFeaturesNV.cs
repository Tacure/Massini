namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceRawAccessChainsFeaturesNV
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint shaderRawAccessChains;
    }
}
