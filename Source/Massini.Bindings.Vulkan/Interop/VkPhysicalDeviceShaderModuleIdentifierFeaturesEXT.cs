namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceShaderModuleIdentifierFeaturesEXT
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint shaderModuleIdentifier;
    }
}
