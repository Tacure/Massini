namespace Massini.Bindings.Vulkan
{
    [NativeTypeName("unsigned int")]
    public enum VkConservativeRasterizationModeEXT : uint
    {
        VK_CONSERVATIVE_RASTERIZATION_MODE_DISABLED_EXT = 0,
        VK_CONSERVATIVE_RASTERIZATION_MODE_OVERESTIMATE_EXT = 1,
        VK_CONSERVATIVE_RASTERIZATION_MODE_UNDERESTIMATE_EXT = 2,
        VK_CONSERVATIVE_RASTERIZATION_MODE_MAX_ENUM_EXT = 0x7FFFFFFF,
    }
}
