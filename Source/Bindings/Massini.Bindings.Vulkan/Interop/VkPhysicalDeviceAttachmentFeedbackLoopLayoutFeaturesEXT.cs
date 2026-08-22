namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceAttachmentFeedbackLoopLayoutFeaturesEXT
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint attachmentFeedbackLoopLayout;
    }
}
