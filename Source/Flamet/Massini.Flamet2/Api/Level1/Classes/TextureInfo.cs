
using Massini.Core;
using Massini.Core.Math.Primitives;
using Massini.Flamet2.Api.Level1.Enums;
using Massini.Flamet2.Api.Level1.Interfaces;

namespace Massini.Flamet2.Api.Level1.Classes
{
    /// <summary>
    /// Texture information.
    /// </summary>
    public sealed class TextureInfo
    {
        /// <summary>
        /// Texture unique id.
        /// </summary>
        public Rid Id { get; internal init; }
        /// <summary>
        /// The device that created the texture.
        /// </summary>
        public IDevice1 Device { get; internal init; }
        public TextureType TextureType { get; internal init; }
        public TextureFormat Format { get; internal init; }
        public SampleCount SampleCount { get; internal init; }
        public Vec3<uint> Extent { get; internal init; } 
        public uint MipCount { get; internal init; }
        public uint ArrayLayerCount { get; internal init; }
    }   
}