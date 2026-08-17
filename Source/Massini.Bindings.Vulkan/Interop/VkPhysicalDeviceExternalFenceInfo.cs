namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceExternalFenceInfo
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public VkExternalFenceHandleTypeFlagBits handleType;
    }
}
