namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkImageCaptureDescriptorDataInfoEXT
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkImage")]
        public VkImage_T* image;
    }
}
