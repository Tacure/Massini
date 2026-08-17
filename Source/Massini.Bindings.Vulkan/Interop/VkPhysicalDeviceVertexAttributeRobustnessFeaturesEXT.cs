namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceVertexAttributeRobustnessFeaturesEXT
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint vertexAttributeRobustness;
    }
}
