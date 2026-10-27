
using Massini.Core.Functional;
using Massini.Core.Math.Primitives;
using Massini.Flamet2.Api.Level1.Enums;
using Massini.Flamet2.Api.Level1.Interfaces;

namespace Massini.Flamet2.Api.Level1.Structs
{
    public struct SwapchainCreateParams : INext
    {
        public required INext? p_next;
        public required ISurface1 p_surface;
        public required Vec2<uint> p_size;
        public required uint p_frameCount;
        public required PresentMode p_presentMode;
        public required TextureFormat p_colorFormat;
        public required CompositeAlphaModeFlags p_compositeAlphaMode;
        public required ColorSpace p_colorSpace;
        
        public readonly INext? Next => p_next;
    }   
}