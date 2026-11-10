
using Massini.Flamet2.Api.Level1.Enums;

namespace Massini.Flamet2.Api.Level1.Structs
{
    public struct DeviceCreateParams
    {
        public required bool p_enableDebugMode;
        public required bool p_enableSwapchain;
        public required WindowManager p_windowManager;
        public Action<LogLevel, string>? p_logCallback;
    }    
}
