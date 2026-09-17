namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkExternalComputeQueueCreateInfoNV
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkQueue")]
        public VkQueue_T* preferredQueue;
    }
}
