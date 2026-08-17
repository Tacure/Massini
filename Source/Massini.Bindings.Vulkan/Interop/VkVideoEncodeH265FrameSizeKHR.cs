namespace Massini.Bindings.Vulkan
{
    public partial struct VkVideoEncodeH265FrameSizeKHR
    {
        [NativeTypeName("uint32_t")]
        public uint frameISize;

        [NativeTypeName("uint32_t")]
        public uint framePSize;

        [NativeTypeName("uint32_t")]
        public uint frameBSize;
    }
}
