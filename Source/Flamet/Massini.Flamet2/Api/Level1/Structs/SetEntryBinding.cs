
using Massini.Core.Functional;

namespace Massini.Flamet2.Api.Level1.Structs
{
    public struct SetEntryBinding
    {
        public required uint p_binding;
        public required Either<BufferBindingDescription, TextureBindingDescription> p_bindingDescription;
    }
}