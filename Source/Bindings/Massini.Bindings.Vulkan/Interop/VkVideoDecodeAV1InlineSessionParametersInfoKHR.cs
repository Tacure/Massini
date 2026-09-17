namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkVideoDecodeAV1InlineSessionParametersInfoKHR
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("const StdVideoAV1SequenceHeader *")]
        public StdVideoAV1SequenceHeader* pStdSequenceHeader;
    }
}
