namespace Massini.Bindings.Vulkan
{
    [NativeTypeName("unsigned int")]
    public enum VkMemoryHeapFlagBits : uint
    {
        VK_MEMORY_HEAP_DEVICE_LOCAL_BIT = 0x00000001,
        VK_MEMORY_HEAP_MULTI_INSTANCE_BIT = 0x00000002,
        VK_MEMORY_HEAP_TILE_MEMORY_BIT_QCOM = 0x00000008,
        VK_MEMORY_HEAP_MULTI_INSTANCE_BIT_KHR = VK_MEMORY_HEAP_MULTI_INSTANCE_BIT,
        VK_MEMORY_HEAP_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF,
    }
}
