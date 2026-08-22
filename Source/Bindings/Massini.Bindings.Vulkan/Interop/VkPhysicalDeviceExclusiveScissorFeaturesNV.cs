namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceExclusiveScissorFeaturesNV
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint exclusiveScissor;
    }
}
