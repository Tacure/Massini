namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceRobustness2FeaturesEXT
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint robustBufferAccess2;

        [NativeTypeName("VkBool32")]
        public uint robustImageAccess2;

        [NativeTypeName("VkBool32")]
        public uint nullDescriptor;
    }
}
