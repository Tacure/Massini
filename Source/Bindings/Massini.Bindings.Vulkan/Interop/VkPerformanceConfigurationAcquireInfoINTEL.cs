namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPerformanceConfigurationAcquireInfoINTEL
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public VkPerformanceConfigurationTypeINTEL type;
    }
}
