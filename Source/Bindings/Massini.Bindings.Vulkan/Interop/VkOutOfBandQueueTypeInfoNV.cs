namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkOutOfBandQueueTypeInfoNV
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public VkOutOfBandQueueTypeNV queueType;
    }
}
