namespace Massini.Bindings.Vulkan
{
    [NativeTypeName("unsigned int")]
    public enum VkSamplerMipmapMode : uint
    {
        VK_SAMPLER_MIPMAP_MODE_NEAREST = 0,
        VK_SAMPLER_MIPMAP_MODE_LINEAR = 1,
        VK_SAMPLER_MIPMAP_MODE_MAX_ENUM = 0x7FFFFFFF,
    }
}
