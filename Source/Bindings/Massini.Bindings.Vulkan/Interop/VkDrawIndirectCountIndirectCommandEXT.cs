namespace Massini.Bindings.Vulkan
{
    public partial struct VkDrawIndirectCountIndirectCommandEXT
    {
        [NativeTypeName("VkDeviceAddress")]
        public ulong bufferAddress;

        [NativeTypeName("uint32_t")]
        public uint stride;

        [NativeTypeName("uint32_t")]
        public uint commandCount;
    }
}
