namespace Massini.Bindings.Vulkan
{
    [NativeTypeName("unsigned int")]
    public enum VkChromaLocation : uint
    {
        VK_CHROMA_LOCATION_COSITED_EVEN = 0,
        VK_CHROMA_LOCATION_MIDPOINT = 1,
        VK_CHROMA_LOCATION_COSITED_EVEN_KHR = VK_CHROMA_LOCATION_COSITED_EVEN,
        VK_CHROMA_LOCATION_MIDPOINT_KHR = VK_CHROMA_LOCATION_MIDPOINT,
        VK_CHROMA_LOCATION_MAX_ENUM = 0x7FFFFFFF,
    }
}
