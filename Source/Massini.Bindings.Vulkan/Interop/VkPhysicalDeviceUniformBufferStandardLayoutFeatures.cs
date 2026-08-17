namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceUniformBufferStandardLayoutFeatures
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint uniformBufferStandardLayout;
    }
}
