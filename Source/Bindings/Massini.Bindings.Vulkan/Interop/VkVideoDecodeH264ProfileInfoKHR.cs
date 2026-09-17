namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkVideoDecodeH264ProfileInfoKHR
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public StdVideoH264ProfileIdc stdProfileIdc;

        public VkVideoDecodeH264PictureLayoutFlagBitsKHR pictureLayout;
    }
}
