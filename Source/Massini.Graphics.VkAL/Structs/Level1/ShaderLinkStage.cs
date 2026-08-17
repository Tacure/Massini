
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Interfaces;

namespace Massini.Graphics.VkAL.Structs.Level1
{
    public struct ShaderLinkStage : INext
    {
        public required INext? p_next;
        public required ShaderStageFlags p_stage;
        public required byte[] p_code;
        public required string p_entryPoint;

        /// <inheritdoc/>
        public readonly INext? Next => p_next;
    }
}