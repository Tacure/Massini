namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceShaderUniformBufferUnsizedArrayFeaturesEXT
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint shaderUniformBufferUnsizedArray;
    }
}
