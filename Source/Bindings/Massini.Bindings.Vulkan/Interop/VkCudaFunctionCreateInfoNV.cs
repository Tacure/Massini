namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkCudaFunctionCreateInfoNV
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkCudaModuleNV")]
        public VkCudaModuleNV_T* module;

        [NativeTypeName("const char *")]
        public sbyte* pName;
    }
}
