namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkQueryPoolVideoEncodeFeedbackCreateInfoKHR
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkVideoEncodeFeedbackFlagsKHR")]
        public uint encodeFeedbackFlags;
    }
}
