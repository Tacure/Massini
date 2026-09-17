namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceMemoryDecompressionFeaturesEXT
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint memoryDecompression;
    }
}
