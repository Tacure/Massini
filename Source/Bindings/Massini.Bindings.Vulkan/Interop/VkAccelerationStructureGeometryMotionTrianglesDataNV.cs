namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkAccelerationStructureGeometryMotionTrianglesDataNV
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public VkDeviceOrHostAddressConstKHR vertexData;
    }
}
