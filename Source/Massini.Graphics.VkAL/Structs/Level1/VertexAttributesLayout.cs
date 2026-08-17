
using Massini.Graphics.VkAL.Enums;

namespace Massini.Graphics.VkAL.Structs.Level1
{
    public struct VertexAttributesLayout
    {
        public required uint p_binding;
        public required uint p_stride;
        public required VertexStepMode p_stepMode;
        public required VertexAttribute[] p_attributes;
    }
}
