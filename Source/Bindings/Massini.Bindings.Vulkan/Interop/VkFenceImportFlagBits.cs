namespace Massini.Bindings.Vulkan
{
    [NativeTypeName("unsigned int")]
    public enum VkFenceImportFlagBits : uint
    {
        VK_FENCE_IMPORT_TEMPORARY_BIT = 0x00000001,
        VK_FENCE_IMPORT_TEMPORARY_BIT_KHR = VK_FENCE_IMPORT_TEMPORARY_BIT,
        VK_FENCE_IMPORT_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF,
    }
}
