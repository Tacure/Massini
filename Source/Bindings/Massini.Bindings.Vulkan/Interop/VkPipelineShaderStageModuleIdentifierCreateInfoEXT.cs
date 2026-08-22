namespace Massini.Bindings.Vulkan
{
    public unsafe partial struct VkPipelineShaderStageModuleIdentifierCreateInfoEXT
    {
        public VkStructureType sType;

        [NativeTypeName("const void *")]
        public void* pNext;

        [NativeTypeName("uint32_t")]
        public uint identifierSize;

        [NativeTypeName("const uint8_t *")]
        public byte* pIdentifier;
    }
}
