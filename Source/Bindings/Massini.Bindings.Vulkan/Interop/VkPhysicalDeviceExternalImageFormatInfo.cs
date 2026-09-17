namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceExternalImageFormatInfo
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public VkExternalMemoryHandleTypeFlagBits handleType;
    }
}
