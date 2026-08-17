namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkMultisampledRenderToSingleSampledInfoEXT
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint multisampledRenderToSingleSampledEnable;

        public VkSampleCountFlagBits rasterizationSamples;
    }
}
