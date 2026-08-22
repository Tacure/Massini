namespace Massini.Bindings.Vulkan
{
    public partial struct VkCopyMemoryIndirectCommandNV
    {
        [NativeTypeName("VkDeviceAddress")]
        public ulong srcAddress;

        [NativeTypeName("VkDeviceAddress")]
        public ulong dstAddress;

        [NativeTypeName("VkDeviceSize")]
        public ulong size;
    }
}
