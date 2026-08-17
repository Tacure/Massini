namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPipelineRasterizationStateRasterizationOrderAMD
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public VkRasterizationOrderAMD rasterizationOrder;
    }
}
