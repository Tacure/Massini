using Massini.Flamet2.Api.Level1.Enums;

namespace Massini.Flamet2.Api.Level1.Structs
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
