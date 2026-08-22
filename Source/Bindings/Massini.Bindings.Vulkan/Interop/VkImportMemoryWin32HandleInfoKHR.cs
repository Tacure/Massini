namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkImportMemoryWin32HandleInfoKHR
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public VkExternalMemoryHandleTypeFlagBits handleType;

        [NativeTypeName("HANDLE")]
        public void* handle;

        [NativeTypeName("LPCWSTR")]
        public ushort* name;
    }
}
