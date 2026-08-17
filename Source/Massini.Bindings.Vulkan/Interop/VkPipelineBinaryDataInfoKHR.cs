namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPipelineBinaryDataInfoKHR
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkPipelineBinaryKHR")]
        public VkPipelineBinaryKHR_T* pipelineBinary;
    }
}
