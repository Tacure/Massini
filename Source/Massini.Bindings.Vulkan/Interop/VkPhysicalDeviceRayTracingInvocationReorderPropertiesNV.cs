namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceRayTracingInvocationReorderPropertiesNV
    {
        public VkStructureType sType;

        public void* pNext;

        public VkRayTracingInvocationReorderModeNV rayTracingInvocationReorderReorderingHint;
    }
}
