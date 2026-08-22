namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceFragmentShaderBarycentricFeaturesKHR
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint fragmentShaderBarycentric;
    }
}
