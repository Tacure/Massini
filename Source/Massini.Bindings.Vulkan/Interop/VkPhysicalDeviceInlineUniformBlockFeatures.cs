namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPhysicalDeviceInlineUniformBlockFeatures
    {
        public VkStructureType sType;

        public void* pNext;

        [NativeTypeName("VkBool32")]
        public uint inlineUniformBlock;

        [NativeTypeName("VkBool32")]
        public uint descriptorBindingInlineUniformBlockUpdateAfterBind;
    }
}
