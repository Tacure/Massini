namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkCopyMicromapInfoEXT
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkMicromapEXT")]
        public VkMicromapEXT_T* src;

        [NativeTypeName("VkMicromapEXT")]
        public VkMicromapEXT_T* dst;

        public VkCopyMicromapModeEXT mode;
    }
}
