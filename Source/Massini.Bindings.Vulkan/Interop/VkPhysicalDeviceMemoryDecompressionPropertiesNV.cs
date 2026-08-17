namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceMemoryDecompressionPropertiesNV
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkMemoryDecompressionMethodFlagsNV")]
        public ulong decompressionMethods;

        [NativeTypeName("uint64_t")]
        public ulong maxDecompressionIndirectCount;
    }
}
