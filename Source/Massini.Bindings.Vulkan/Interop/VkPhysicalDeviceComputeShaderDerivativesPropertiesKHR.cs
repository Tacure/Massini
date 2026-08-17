namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceComputeShaderDerivativesPropertiesKHR
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint meshAndTaskShaderDerivatives;
    }
}
