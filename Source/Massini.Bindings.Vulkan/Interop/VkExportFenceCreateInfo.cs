namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkExportFenceCreateInfo
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkExternalFenceHandleTypeFlags")]
        public uint handleTypes;
    }
}
