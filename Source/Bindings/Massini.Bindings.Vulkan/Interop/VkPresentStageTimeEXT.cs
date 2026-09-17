namespace Massini.Bindings.Vulkan
{
    public partial struct VkPresentStageTimeEXT
    {
        [NativeTypeName("VkPresentStageFlagsEXT")]
        public uint stage;

        [NativeTypeName("uint64_t")]
        public ulong time;
    }
}
