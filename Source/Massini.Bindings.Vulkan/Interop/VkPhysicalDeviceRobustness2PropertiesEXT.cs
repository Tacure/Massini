namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceRobustness2PropertiesEXT
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkDeviceSize")]
        public ulong robustStorageBufferAccessSizeAlignment;

        [NativeTypeName("VkDeviceSize")]
        public ulong robustUniformBufferAccessSizeAlignment;
    }
}
