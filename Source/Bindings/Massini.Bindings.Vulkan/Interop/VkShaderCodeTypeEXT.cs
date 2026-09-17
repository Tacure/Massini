namespace Massini.Bindings.Vulkan
{
    [NativeTypeName("unsigned int")]
    public enum VkShaderCodeTypeEXT : uint
    {
        VK_SHADER_CODE_TYPE_BINARY_EXT = 0,
        VK_SHADER_CODE_TYPE_SPIRV_EXT = 1,
        VK_SHADER_CODE_TYPE_MAX_ENUM_EXT = 0x7FFFFFFF,
    }
}
