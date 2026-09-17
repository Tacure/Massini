namespace Massini.Bindings.Vulkan
{
    [NativeTypeName("unsigned int")]
    public enum VkBlendOverlapEXT : uint
    {
        VK_BLEND_OVERLAP_UNCORRELATED_EXT = 0,
        VK_BLEND_OVERLAP_DISJOINT_EXT = 1,
        VK_BLEND_OVERLAP_CONJOINT_EXT = 2,
        VK_BLEND_OVERLAP_MAX_ENUM_EXT = 0x7FFFFFFF,
    }
}
