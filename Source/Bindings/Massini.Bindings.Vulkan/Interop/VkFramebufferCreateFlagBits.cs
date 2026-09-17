namespace Massini.Bindings.Vulkan
{
    [NativeTypeName("unsigned int")]
    public enum VkFramebufferCreateFlagBits : uint
    {
        VK_FRAMEBUFFER_CREATE_IMAGELESS_BIT = 0x00000001,
        VK_FRAMEBUFFER_CREATE_IMAGELESS_BIT_KHR = VK_FRAMEBUFFER_CREATE_IMAGELESS_BIT,
        VK_FRAMEBUFFER_CREATE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF,
    }
}
