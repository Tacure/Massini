
using Massini.Graphics.VkAL.Interfaces;
using Massini.Graphics.VkAL.Structs.Level1;

namespace Massini.Graphics.VkAL.Sugar.Structs
{
    public struct SmartShaderLinkCreateParams : INext
    {
        public INext? p_next;
        public string p_label;
        public ShaderLinkStage[] p_stages;

        public readonly INext? Next => p_next;
    }
}
