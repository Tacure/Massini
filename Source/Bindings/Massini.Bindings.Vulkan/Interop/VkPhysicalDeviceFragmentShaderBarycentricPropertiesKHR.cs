namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceFragmentShaderBarycentricPropertiesKHR
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint triStripVertexOrderIndependentOfProvokingVertex;
    }
}
