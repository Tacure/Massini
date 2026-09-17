namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkDataGraphPipelineDispatchInfoARM
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkDataGraphPipelineDispatchFlagsARM")]
        public ulong flags;
    }
}
