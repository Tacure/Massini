namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkGraphicsPipelineLibraryCreateInfoEXT
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("VkGraphicsPipelineLibraryFlagsEXT")]
        public uint flags;
    }
}
