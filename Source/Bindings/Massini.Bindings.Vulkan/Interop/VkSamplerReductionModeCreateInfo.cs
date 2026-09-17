namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkSamplerReductionModeCreateInfo
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public VkSamplerReductionMode reductionMode;
    }
}
