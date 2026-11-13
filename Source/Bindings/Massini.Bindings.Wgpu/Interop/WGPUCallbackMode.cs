namespace Massini.Bindings.Wgpu
{
    public enum WGPUCallbackMode
    {
        WGPUCallbackMode_WaitAnyOnly = 0x00000001,
        WGPUCallbackMode_AllowProcessEvents = 0x00000002,
        WGPUCallbackMode_AllowSpontaneous = 0x00000003,
        WGPUCallbackMode_Force32 = 0x7FFFFFFF,
    }
}
