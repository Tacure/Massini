namespace Massini.Bindings.Vulkan
{
    [NativeTypeName("unsigned int")]
    public enum VkHostImageCopyFlagBits : uint
    {
        VK_HOST_IMAGE_COPY_MEMCPY_BIT = 0x00000001,
        VK_HOST_IMAGE_COPY_MEMCPY = VK_HOST_IMAGE_COPY_MEMCPY_BIT,
        VK_HOST_IMAGE_COPY_MEMCPY_BIT_EXT = VK_HOST_IMAGE_COPY_MEMCPY_BIT,
        VK_HOST_IMAGE_COPY_MEMCPY_EXT = VK_HOST_IMAGE_COPY_MEMCPY_BIT,
        VK_HOST_IMAGE_COPY_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF,
    }
}
