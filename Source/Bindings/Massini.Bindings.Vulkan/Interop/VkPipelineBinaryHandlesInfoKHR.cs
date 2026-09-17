namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPipelineBinaryHandlesInfoKHR
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("uint32_t")]
        public uint pipelineBinaryCount;

        [NativeTypeName("VkPipelineBinaryKHR *")]
        public VkPipelineBinaryKHR_T** pPipelineBinaries;
    }
}
