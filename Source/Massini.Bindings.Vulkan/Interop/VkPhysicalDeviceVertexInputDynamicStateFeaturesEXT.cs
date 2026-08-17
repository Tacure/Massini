namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceVertexInputDynamicStateFeaturesEXT
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint vertexInputDynamicState;
    }
}
