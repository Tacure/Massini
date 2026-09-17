namespace Massini.Bindings.Vulkan
{
    [NativeTypeName("unsigned int")]
    public enum VkAddressCopyFlagBitsKHR : uint
    {
        VK_ADDRESS_COPY_DEVICE_LOCAL_BIT_KHR = 0x00000001,
        VK_ADDRESS_COPY_SPARSE_BIT_KHR = 0x00000002,
        VK_ADDRESS_COPY_PROTECTED_BIT_KHR = 0x00000004,
        VK_ADDRESS_COPY_FLAG_BITS_MAX_ENUM_KHR = 0x7FFFFFFF,
    }
}
