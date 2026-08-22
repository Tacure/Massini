namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceClusterCullingShaderFeaturesHUAWEI
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint clustercullingShader;

        [NativeTypeName("VkBool32")]
        public uint multiviewClusterCullingShader;
    }
}
