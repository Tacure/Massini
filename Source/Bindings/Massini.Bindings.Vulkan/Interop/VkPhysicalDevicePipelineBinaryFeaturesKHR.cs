namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDevicePipelineBinaryFeaturesKHR
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint pipelineBinaries;
    }
}
