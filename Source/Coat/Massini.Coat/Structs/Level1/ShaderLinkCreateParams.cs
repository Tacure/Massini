using System;
using Massini.Coat.Classes;
using Massini.Coat.Interfaces;

namespace Massini.Coat.Structs.Level1
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