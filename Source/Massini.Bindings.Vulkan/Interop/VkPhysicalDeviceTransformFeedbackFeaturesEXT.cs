namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceTransformFeedbackFeaturesEXT
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint transformFeedback;

        [NativeTypeName("VkBool32")]
        public uint geometryStreams;
    }
}
