using System.Runtime.InteropServices;

namespace Massini.Bindings.Vulkan
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe partial struct VkIndirectExecutionSetInfoEXT
    {
        [FieldOffset(0)]
        [NativeTypeName("const VkIndirectExecutionSetPipelineInfoEXT *")]
        public VkIndirectExecutionSetPipelineInfoEXT* pPipelineInfo;

        [FieldOffset(0)]
        [NativeTypeName("const VkIndirectExecutionSetShaderInfoEXT *")]
        public VkIndirectExecutionSetShaderInfoEXT* pShaderInfo;
    }
}
