namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceShaderSubgroupExtendedTypesFeatures
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint shaderSubgroupExtendedTypes;
    }
}
