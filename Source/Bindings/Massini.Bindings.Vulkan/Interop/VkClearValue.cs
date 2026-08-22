using System.Runtime.InteropServices;

namespace Massini.Bindings.Vulkan
{
    [StructLayout(LayoutKind.Explicit)]
    public partial struct VkClearValue
    {
        [FieldOffset(0)]
        public VkClearColorValue color;

        [FieldOffset(0)]
        public VkClearDepthStencilValue depthStencil;
    }
}
