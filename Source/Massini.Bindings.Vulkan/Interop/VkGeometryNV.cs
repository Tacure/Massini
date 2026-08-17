namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkGeometryNV
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public VkGeometryTypeKHR geometryType;

        public VkGeometryDataNV geometry;

        [NativeTypeName("VkGeometryFlagsKHR")]
        public uint flags;
    }
}
