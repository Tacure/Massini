namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkAccelerationStructureGeometryAabbsDataKHR
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public VkDeviceOrHostAddressConstKHR data;

        [NativeTypeName("VkDeviceSize")]
        public ulong stride;
    }
}
