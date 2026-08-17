namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkMemoryBarrier
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkAccessFlags")]
        public uint srcAccessMask;

        [NativeTypeName("VkAccessFlags")]
        public uint dstAccessMask;
    }
}
