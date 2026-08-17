namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkImageViewASTCDecodeModeEXT
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        public VkFormat decodeMode;
    }
}
