namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkSemaphoreGetWin32HandleInfoKHR
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkSemaphore")]
        public VkSemaphore_T* semaphore;

        public VkExternalSemaphoreHandleTypeFlagBits handleType;
    }
}
