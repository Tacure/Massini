namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPipelineRasterizationProvokingVertexStateCreateInfoEXT
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public VkProvokingVertexModeEXT provokingVertexMode;
    }
}
