namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkImportFenceWin32HandleInfoKHR
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkFence")]
        public VkFence_T* fence;

        [NativeTypeName("VkFenceImportFlags")]
        public uint flags;

        public VkExternalFenceHandleTypeFlagBits handleType;

        [NativeTypeName("HANDLE")]
        public void* handle;

        [NativeTypeName("LPCWSTR")]
        public ushort* name;
    }
}
