namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkCudaModuleCreateInfoNV
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("size_t")]
        public nuint dataSize;

        [NativeTypeName("const void *")]
        public void* pData;
    }
}
