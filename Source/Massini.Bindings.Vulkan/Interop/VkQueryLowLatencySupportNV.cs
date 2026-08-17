namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkQueryLowLatencySupportNV
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public void* pQueriedLowLatencyData;
    }
}
