namespace Massini.Bindings.Vulkan
{
    public partial struct VkDeviceFaultAddressInfoEXT
    {
        public VkDeviceFaultAddressTypeEXT addressType;

        [NativeTypeName("VkDeviceAddress")]
        public ulong reportedAddress;

        [NativeTypeName("VkDeviceSize")]
        public ulong addressPrecision;
    }
}
