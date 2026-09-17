namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkDataGraphPipelineSessionBindPointRequirementsInfoARM
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkDataGraphPipelineSessionARM")]
        public VkDataGraphPipelineSessionARM_T* session;
    }
}
