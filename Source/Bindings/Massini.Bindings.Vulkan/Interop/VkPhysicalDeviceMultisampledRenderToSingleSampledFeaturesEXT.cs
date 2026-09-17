namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceMultisampledRenderToSingleSampledFeaturesEXT
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint multisampledRenderToSingleSampled;
    }
}
