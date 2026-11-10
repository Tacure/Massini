
using Massini.Flamet2.Api.Level1.Enums;

namespace Massini.Flamet2.Impl.Structs
{
    public struct InstanceCreateParams
    {
        public required string p_label;
        public WindowManager p_windowManager;
        public required InstanceFeatures p_features;
    }
}
