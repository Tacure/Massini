namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPartitionedAccelerationStructureFlagsNV
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint enablePartitionTranslation;
    }
}
