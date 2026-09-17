namespace Massini.Bindings.Vulkan
{
    [NativeTypeName("unsigned int")]
    public enum VkMemoryOverallocationBehaviorAMD : uint
    {
        VK_MEMORY_OVERALLOCATION_BEHAVIOR_DEFAULT_AMD = 0,
        VK_MEMORY_OVERALLOCATION_BEHAVIOR_ALLOWED_AMD = 1,
        VK_MEMORY_OVERALLOCATION_BEHAVIOR_DISALLOWED_AMD = 2,
        VK_MEMORY_OVERALLOCATION_BEHAVIOR_MAX_ENUM_AMD = 0x7FFFFFFF,
    }
}
