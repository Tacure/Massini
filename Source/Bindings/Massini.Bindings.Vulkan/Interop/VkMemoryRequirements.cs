namespace Massini.Bindings.Vulkan
{
    public partial struct VkMemoryRequirements
    {
        [NativeTypeName("VkDeviceSize")]
        public ulong size;

        [NativeTypeName("VkDeviceSize")]
        public ulong alignment;

        [NativeTypeName("uint32_t")]
        public uint memoryTypeBits;
    }
}
