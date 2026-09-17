namespace Massini.Bindings.Vulkan
{
    public partial struct VkBufferCopy
    {
        [NativeTypeName("VkDeviceSize")]
        public ulong srcOffset;

        [NativeTypeName("VkDeviceSize")]
        public ulong dstOffset;

        [NativeTypeName("VkDeviceSize")]
        public ulong size;
    }
}
