
using Massini.Flamet2.Api.Level1.Interfaces;

namespace Massini.Flamet2.Api.Level1.Structs
{
    public struct SetCreateParams
    {
        public required ISetAllocator1 p_setAllocator;
        public required ILayout1 p_layout;
        public required uint p_setLayoutIdx;
        public required SetEntryBinding[] p_bindings;
    }   
}