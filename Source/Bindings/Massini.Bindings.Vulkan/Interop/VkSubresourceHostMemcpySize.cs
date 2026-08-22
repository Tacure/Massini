namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkSubresourceHostMemcpySize
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkDeviceSize")]
        public ulong size;
    }
}
