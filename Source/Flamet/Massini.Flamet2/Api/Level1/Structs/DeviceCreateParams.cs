
using Massini.Flamet2.Api.Level1.Enums;

namespace Massini.Flamet2.Api.Level1.Structs
{
    public struct DeviceCreateParams
    {
        public bool p_enableDebugMode;
        public bool p_enableSwapchain;
        public Action<LogLevel, string>? p_logCallback;
    }    
}
