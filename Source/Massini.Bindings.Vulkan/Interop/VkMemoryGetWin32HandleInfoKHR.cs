namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkMemoryGetWin32HandleInfoKHR
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkDeviceMemory")]
        public VkDeviceMemory_T* memory;

        public VkExternalMemoryHandleTypeFlagBits handleType;
    }
}
