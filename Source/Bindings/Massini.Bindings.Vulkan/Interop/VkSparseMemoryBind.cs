namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkSparseMemoryBind
    {
        [NativeTypeName("VkDeviceSize")]
        public ulong resourceOffset;

        [NativeTypeName("VkDeviceSize")]
        public ulong size;

        [NativeTypeName("VkDeviceMemory")]
        public VkDeviceMemory_T* memory;

        [NativeTypeName("VkDeviceSize")]
        public ulong memoryOffset;

        [NativeTypeName("VkSparseMemoryBindFlags")]
        public uint flags;
    }
}
