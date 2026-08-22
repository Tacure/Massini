namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkFenceGetWin32HandleInfoKHR
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkFence")]
        public VkFence_T* fence;

        public VkExternalFenceHandleTypeFlagBits handleType;
    }
}
