namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkDeviceGroupCommandBufferBeginInfo
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("uint32_t")]
        public uint deviceMask;
    }
}
