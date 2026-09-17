namespace Massini.Bindings.Vulkan
{
    [NativeTypeName("unsigned int")]
    public enum VkSemaphoreImportFlagBits : uint
    {
        VK_SEMAPHORE_IMPORT_TEMPORARY_BIT = 0x00000001,
        VK_SEMAPHORE_IMPORT_TEMPORARY_BIT_KHR = VK_SEMAPHORE_IMPORT_TEMPORARY_BIT,
        VK_SEMAPHORE_IMPORT_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF,
    }
}
