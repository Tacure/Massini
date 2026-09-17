namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkAccelerationStructureVersionInfoKHR
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("const uint8_t *")]
        public byte* pVersionData;
    }
}
