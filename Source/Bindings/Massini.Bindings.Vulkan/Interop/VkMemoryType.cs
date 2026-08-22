namespace Massini.Bindings.Vulkan
{
    public partial struct VkMemoryType
    {
        [NativeTypeName("VkMemoryPropertyFlags")]
        public uint propertyFlags;

        [NativeTypeName("uint32_t")]
        public uint heapIndex;
    }
}
