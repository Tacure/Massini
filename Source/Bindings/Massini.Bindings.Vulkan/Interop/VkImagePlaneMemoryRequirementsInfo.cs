namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkImagePlaneMemoryRequirementsInfo
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public VkImageAspectFlagBits planeAspect;
    }
}
