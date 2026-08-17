namespace Massini.Bindings.Vulkan
{
    public partial struct VkStridedDeviceAddressRegionKHR
    {
        [NativeTypeName("VkDeviceAddress")]
        public ulong deviceAddress;

        [NativeTypeName("VkDeviceSize")]
        public ulong stride;

        [NativeTypeName("VkDeviceSize")]
        public ulong size;
    }
}
