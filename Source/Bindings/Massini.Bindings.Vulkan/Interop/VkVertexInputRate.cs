namespace Massini.Bindings.Vulkan
{
    [NativeTypeName("unsigned int")]
    public enum VkVertexInputRate : uint
    {
        VK_VERTEX_INPUT_RATE_VERTEX = 0,
        VK_VERTEX_INPUT_RATE_INSTANCE = 1,
        VK_VERTEX_INPUT_RATE_MAX_ENUM = 0x7FFFFFFF,
    }
}
