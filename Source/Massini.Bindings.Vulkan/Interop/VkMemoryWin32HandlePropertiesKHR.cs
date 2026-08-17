namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkMemoryWin32HandlePropertiesKHR
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("uint32_t")]
        public uint memoryTypeBits;
    }
}
