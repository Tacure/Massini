namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkIndirectCommandsStreamNV
    {
        [NativeTypeName("VkBuffer")]
        public VkBuffer_T* buffer;

        [NativeTypeName("VkDeviceSize")]
        public ulong offset;
    }
}
