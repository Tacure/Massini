using Massini.Core.Math.Primitives;
using Massini.Flamet.Classes;
using Massini.Flamet.Enums;
using Massini.Flamet.Interfaces;

namespace Massini.Flamet.Structs.Level1
{
    public struct SwapchainCreateParams : INext
    {
        public required INext? p_next;
        public required string p_label;
        public required Surface p_surface;
        public required Vec2<uint> p_size;
        public required uint p_maxFramesInFlight;
        public required PresentModeFlags p_presentMode;
        public required TextureFormat p_colorFormat;
        public required CompositeAlphaModeFlags p_compositeAlphaMode;
        public required TextureFormat p_depthFormat;
        public required bool p_enableDepthBuffer;
        public required ColorSpace p_colorSpace;

        public readonly INext? Next => p_next;
    }
}
