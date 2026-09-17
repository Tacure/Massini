namespace Massini.Bindings.Vulkan
{
    [NativeTypeName("unsigned int")]
    public enum VkSharingMode : uint
    {
        VK_SHARING_MODE_EXCLUSIVE = 0,
        VK_SHARING_MODE_CONCURRENT = 1,
        VK_SHARING_MODE_MAX_ENUM = 0x7FFFFFFF,
    }
}
