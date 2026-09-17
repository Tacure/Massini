namespace Massini.Bindings.Vulkan
{
    [NativeTypeName("unsigned int")]
    public enum VkSubmitFlagBits : uint
    {
        VK_SUBMIT_PROTECTED_BIT = 0x00000001,
        VK_SUBMIT_PROTECTED_BIT_KHR = VK_SUBMIT_PROTECTED_BIT,
        VK_SUBMIT_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF,
    }
}
