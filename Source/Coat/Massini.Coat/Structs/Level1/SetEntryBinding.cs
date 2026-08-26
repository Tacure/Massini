
using Massini.Coat.Enums;
using Massini.Coat.Interfaces;

namespace Massini.Coat.Structs.Level1
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
