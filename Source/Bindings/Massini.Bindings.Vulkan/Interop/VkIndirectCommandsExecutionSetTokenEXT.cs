namespace Massini.Bindings.Vulkan
{
    public partial struct VkIndirectCommandsExecutionSetTokenEXT
    {
        public VkIndirectExecutionSetInfoTypeEXT type;

        [NativeTypeName("VkShaderStageFlags")]
        public uint shaderStages;
    }
}
