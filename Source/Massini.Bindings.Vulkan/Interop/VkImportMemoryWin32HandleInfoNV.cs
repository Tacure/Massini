namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkImportMemoryWin32HandleInfoNV
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkExternalMemoryHandleTypeFlagsNV")]
        public uint handleType;

        [NativeTypeName("HANDLE")]
        public void* handle;
    }
}
