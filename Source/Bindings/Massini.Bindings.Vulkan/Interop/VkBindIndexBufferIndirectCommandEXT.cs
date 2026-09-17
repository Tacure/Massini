namespace Massini.Bindings.Vulkan
{
    public partial struct VkBindIndexBufferIndirectCommandEXT
    {
        [NativeTypeName("VkDeviceAddress")]
        public ulong bufferAddress;

        [NativeTypeName("uint32_t")]
        public uint size;

        public VkIndexType indexType;
    }
}
