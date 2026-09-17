namespace Massini.Bindings.Vulkan
{
    [NativeTypeName("unsigned int")]
    public enum VkCommandBufferLevel : uint
    {
        VK_COMMAND_BUFFER_LEVEL_PRIMARY = 0,
        VK_COMMAND_BUFFER_LEVEL_SECONDARY = 1,
        VK_COMMAND_BUFFER_LEVEL_MAX_ENUM = 0x7FFFFFFF,
    }
}
