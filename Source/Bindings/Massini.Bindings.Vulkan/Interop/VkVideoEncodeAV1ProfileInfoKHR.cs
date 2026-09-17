namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkVideoEncodeAV1ProfileInfoKHR
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public StdVideoAV1Profile stdProfile;
    }
}
