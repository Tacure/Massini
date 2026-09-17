namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkMemoryFdPropertiesKHR
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("uint32_t")]
        public uint memoryTypeBits;
    }
}
