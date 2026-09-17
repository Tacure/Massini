namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDevicePipelineProtectedAccessFeatures
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint pipelineProtectedAccess;
    }
}
