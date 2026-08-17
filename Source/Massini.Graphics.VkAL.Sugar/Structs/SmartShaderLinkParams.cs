
using Massini.Graphics.VkAL.Interfaces;

namespace Massini.Graphics.VkAL.Sugar.Structs
{
    public struct SmartShaderLinkParams : INext
    {
        public INext? p_next;
        public SmartShaderLinkParam[] p_params;

        public readonly INext? Next => p_next;
    }
}