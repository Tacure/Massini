

using Massini.Graphics.VkAL.Interfaces;

namespace Massini.Graphics.VkAL.Structs.Level1.Commands
{
    public struct SetColorBlendEquationCmdParams : INext
    {
        public INext? p_next;
        public uint p_firstAttachment; 
        public BlendState[] p_blendEquations;

        public readonly INext? Next => p_next;
    }
}