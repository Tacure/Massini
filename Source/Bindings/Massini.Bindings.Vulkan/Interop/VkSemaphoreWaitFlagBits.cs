namespace Massini.Bindings.Vulkan
{
    [NativeTypeName("unsigned int")]
    public enum VkSemaphoreWaitFlagBits : uint
    {
        VK_SEMAPHORE_WAIT_ANY_BIT = 0x00000001,
        VK_SEMAPHORE_WAIT_ANY_BIT_KHR = VK_SEMAPHORE_WAIT_ANY_BIT,
        VK_SEMAPHORE_WAIT_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF,
    }
}
