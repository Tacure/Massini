using System;
using Massini.Graphics.VkAL.Classes;
using Massini.Graphics.VkAL.Interfaces;

namespace Massini.Graphics.VkAL.Structs.Level1
{
    public struct ShaderLinkCreateParams : INext
    {
        public required INext? p_next;
        public required string p_label;
        public required ShaderLinkStage[] p_stages;
        public required Layout p_layout;
        
        /// <inheritdoc/>
        public readonly INext? Next => p_next;
    }
}