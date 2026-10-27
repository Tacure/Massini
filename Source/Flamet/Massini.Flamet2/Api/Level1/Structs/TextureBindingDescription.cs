
using Massini.Core.Functional;
using Massini.Flamet2.Api.Level1.Interfaces;

namespace Massini.Flamet2.Api.Level1.Structs
{
    public struct TextureBindingDescription
    {
        public required Either<ITextureView1, ISampler1> p_binding;
    }
}