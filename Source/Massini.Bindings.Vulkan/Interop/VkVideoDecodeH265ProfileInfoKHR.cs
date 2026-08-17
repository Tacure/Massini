namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkVideoDecodeH265ProfileInfoKHR
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public StdVideoH265ProfileIdc stdProfileIdc;
    }
}
