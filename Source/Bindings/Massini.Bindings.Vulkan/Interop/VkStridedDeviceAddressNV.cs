namespace Massini.Bindings.Vulkan
{
    public partial struct VkStridedDeviceAddressNV
    {
        [NativeTypeName("VkDeviceAddress")]
        public ulong startAddress;

        [NativeTypeName("VkDeviceSize")]
        public ulong strideInBytes;
    }
}
