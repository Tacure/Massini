
using Massini.Core;
using Massini.Core.Math.Primitives;
using Massini.Flamet2.Api.Level1.Enums;

namespace Massini.Flamet2.Api.Level1.Classes
{
    public sealed class TextureInfo
    {
        public Rid Id { get; internal init; }
        public TextureType TextureType { get; internal init; }
        public TextureFormat Format { get; internal init; }
        public SampleCount SampleCount { get; internal init; }
        public Vec3<uint> Extent { get; internal init; } 
        public uint MipCount { get; internal init; }
        public uint ArrayLayerCount { get; internal init; }
    }   
}