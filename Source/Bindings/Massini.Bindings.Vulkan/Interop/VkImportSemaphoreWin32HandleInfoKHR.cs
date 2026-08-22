namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkImportSemaphoreWin32HandleInfoKHR
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkSemaphore")]
        public VkSemaphore_T* semaphore;

        [NativeTypeName("VkSemaphoreImportFlags")]
        public uint flags;

        public VkExternalSemaphoreHandleTypeFlagBits handleType;

        [NativeTypeName("HANDLE")]
        public void* handle;

        [NativeTypeName("LPCWSTR")]
        public ushort* name;
    }
}
