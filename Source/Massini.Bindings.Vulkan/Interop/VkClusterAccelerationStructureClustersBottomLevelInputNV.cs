namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkClusterAccelerationStructureClustersBottomLevelInputNV
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("uint32_t")]
        public uint maxTotalClusterCount;

        [NativeTypeName("uint32_t")]
        public uint maxClusterCountPerAccelerationStructure;
    }
}
