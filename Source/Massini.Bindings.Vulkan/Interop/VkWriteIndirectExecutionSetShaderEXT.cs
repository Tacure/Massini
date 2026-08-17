namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkWriteIndirectExecutionSetShaderEXT
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("uint32_t")]
        public uint index;

        [NativeTypeName("VkShaderEXT")]
        public VkShaderEXT_T* shader;
    }
}
