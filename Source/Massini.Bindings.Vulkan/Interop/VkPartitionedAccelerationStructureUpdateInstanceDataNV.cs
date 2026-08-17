namespace Massini.Bindings.Vulkan
{
    public partial struct VkPartitionedAccelerationStructureUpdateInstanceDataNV
    {
        [NativeTypeName("uint32_t")]
        public uint instanceIndex;

        [NativeTypeName("uint32_t")]
        public uint instanceContributionToHitGroupIndex;

        [NativeTypeName("VkDeviceAddress")]
        public ulong accelerationStructure;
    }
}
