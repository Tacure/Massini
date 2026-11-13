namespace Massini.Bindings.Wgpu
{
    public enum WGPURequestDeviceStatus
    {
        WGPURequestDeviceStatus_Success = 0x00000001,
        WGPURequestDeviceStatus_CallbackCancelled = 0x00000002,
        WGPURequestDeviceStatus_Error = 0x00000003,
        WGPURequestDeviceStatus_Force32 = 0x7FFFFFFF,
    }
}
