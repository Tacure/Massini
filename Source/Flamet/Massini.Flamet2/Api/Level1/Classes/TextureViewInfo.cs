
using Massini.Core;
using Massini.Flamet2.Api.Level1.Enums;
using Massini.Flamet2.Api.Level1.Interfaces;

namespace Massini.Flamet2.Api.Level1.Classes
{
    public sealed class TextureViewInfo
    {
        public Rid Id { get; internal init; }
        public ITexture1 Texture { get; internal init; }
        public TextureViewType TextureViewType { get; internal init; }
    }   
}