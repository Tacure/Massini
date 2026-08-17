
using Massini.Graphics.VkAL.Enums;
using Massini.Graphics.VkAL.Interfaces;

namespace Massini.Graphics.VkAL.Structs.Level1
{
    public struct SetEntryBinding : INext
    {
        public required INext? p_next;
        public required uint p_binding;
        public required EntryType p_type;
        public required BufferBindingDescription? p_bufferBinding;
        public required TextureBindingDescription? p_textureBinding;

        public readonly INext? Next => p_next;
    }
}
