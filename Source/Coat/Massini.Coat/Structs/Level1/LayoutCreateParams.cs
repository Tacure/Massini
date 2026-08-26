
using Massini.Coat.Interfaces;

namespace Massini.Coat.Structs.Level1
{
    public struct LayoutCreateParams : INext
    {
        public required INext? p_next;
        public required string p_label;
        public required PushConstantDescription? p_pushConstant;
        public required SetDeclaration[] p_sets;

        public readonly INext? Next => p_next;
    }
}
