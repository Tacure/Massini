
namespace Massini.Flamet2.Api.Level1.Classes
{
    public sealed class AdapterFeatures
    {
        public required bool FillModeNonSolid { get; init; }
        public required bool WideLines { get; init; }
        public required bool DepthClamp { get; init; }
        public required bool FragmentStoresAndAtomics { get; init; }
        public required bool SamplerAnisotropy { get; init; }
        public required bool Swapchain { get; init; }
    }
}
