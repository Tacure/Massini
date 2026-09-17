namespace Massini.Bindings.Vulkan
{
    public partial struct VkPipelineCreationFeedback
    {
        [NativeTypeName("VkPipelineCreationFeedbackFlags")]
        public uint flags;

        [NativeTypeName("uint64_t")]
        public ulong duration;
    }
}
