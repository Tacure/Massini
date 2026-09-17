namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceRayTracingValidationFeaturesNV
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint rayTracingValidation;
    }
}
