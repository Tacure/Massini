namespace Massini.Bindings.Vulkan
{
    public partial struct VkTraceRaysIndirectCommandKHR
    {
        [NativeTypeName("uint32_t")]
        public uint width;

        [NativeTypeName("uint32_t")]
        public uint height;

        [NativeTypeName("uint32_t")]
        public uint depth;
    }
}
