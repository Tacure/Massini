namespace Massini.Bindings.Vulkan
{
    public partial struct VkMemoryHeap
    {
        [NativeTypeName("VkDeviceSize")]
        public ulong size;

        [NativeTypeName("VkMemoryHeapFlags")]
        public uint flags;
    }
}
