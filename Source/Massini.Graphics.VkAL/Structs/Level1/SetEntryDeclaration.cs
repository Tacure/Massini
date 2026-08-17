
using Massini.Graphics.VkAL.Enums;

namespace Massini.Graphics.VkAL.Structs.Level1
{
    public struct SetEntryDeclaration
    {
        public required uint p_binding;
        public required EntryType p_type;
        public required uint p_count;
        public required ShaderStageFlags p_stages;
        public required EntryMode p_mode;
    }
}
