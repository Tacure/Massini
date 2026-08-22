namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkDescriptorBufferInfo
    {
        [NativeTypeName("VkBuffer")]
        public VkBuffer_T* buffer;

        [NativeTypeName("VkDeviceSize")]
        public ulong offset;

        [NativeTypeName("VkDeviceSize")]
        public ulong range;
    }
}
