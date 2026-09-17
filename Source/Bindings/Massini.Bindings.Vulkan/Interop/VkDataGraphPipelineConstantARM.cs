namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkDataGraphPipelineConstantARM
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("uint32_t")]
        public uint id;

        [NativeTypeName("const void *")]
        public void* pConstantData;
    }
}
