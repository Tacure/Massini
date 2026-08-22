namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkBlitImageCubicWeightsInfoQCOM
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public VkCubicFilterWeightsQCOM cubicWeights;
    }
}
