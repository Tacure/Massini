namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkVideoCodingControlInfoKHR
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkVideoCodingControlFlagsKHR")]
        public uint flags;
    }
}
