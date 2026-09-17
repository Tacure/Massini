namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkAccelerationStructureBuildSizesInfoKHR
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkDeviceSize")]
        public ulong accelerationStructureSize;

        [NativeTypeName("VkDeviceSize")]
        public ulong updateScratchSize;

        [NativeTypeName("VkDeviceSize")]
        public ulong buildScratchSize;
    }
}
