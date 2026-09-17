namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceRayTracingInvocationReorderFeaturesEXT
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint rayTracingInvocationReorder;
    }
}
