
using Massini.Core;
using Massini.Core.Math.Primitives;
using Massini.Flamet2.Api.Level1.Interfaces;

namespace Massini.Flamet2.Api.Level1.Classes
{
    public sealed class SwapchainInfo
    {
        public Rid Id { get; internal init; }
        public IDevice1 Device { get; internal init; }
        public ISurface1 Surface { get; internal init; }
        public Vec2<uint> Extent { get; internal init; }
        public uint FrameCount { get; internal init; }
    }   
}