namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkWin32KeyedMutexAcquireReleaseInfoKHR
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("uint32_t")]
        public uint acquireCount;

        [NativeTypeName("const VkDeviceMemory *")]
        public VkDeviceMemory_T** pAcquireSyncs;

        [NativeTypeName("const uint64_t *")]
        public ulong* pAcquireKeys;

        [NativeTypeName("const uint32_t *")]
        public uint* pAcquireTimeouts;

        [NativeTypeName("uint32_t")]
        public uint releaseCount;

        [NativeTypeName("const VkDeviceMemory *")]
        public VkDeviceMemory_T** pReleaseSyncs;

        [NativeTypeName("const uint64_t *")]
        public ulong* pReleaseKeys;
    }
}
