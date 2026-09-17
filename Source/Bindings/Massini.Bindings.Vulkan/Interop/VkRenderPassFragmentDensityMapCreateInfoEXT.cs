namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkRenderPassFragmentDensityMapCreateInfoEXT
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public VkAttachmentReference fragmentDensityMapAttachment;
    }
}
