namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceExternalSemaphoreInfo
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public VkExternalSemaphoreHandleTypeFlagBits handleType;
    }
}
