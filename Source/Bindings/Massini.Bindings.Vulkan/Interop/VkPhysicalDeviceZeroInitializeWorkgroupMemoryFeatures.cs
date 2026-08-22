namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceZeroInitializeWorkgroupMemoryFeatures
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint shaderZeroInitializeWorkgroupMemory;
    }
}
