namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkAcquireProfilingLockInfoKHR
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkAcquireProfilingLockFlagsKHR")]
        public uint flags;

        [NativeTypeName("uint64_t")]
        public ulong timeout;
    }
}
