namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDevicePartitionedAccelerationStructureFeaturesNV
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint partitionedAccelerationStructure;
    }
}
