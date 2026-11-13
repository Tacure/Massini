namespace Massini.Bindings.Wgpu
{
    public enum WGPURequestAdapterStatus
    {
        WGPURequestAdapterStatus_Success = 0x00000001,
        WGPURequestAdapterStatus_CallbackCancelled = 0x00000002,
        WGPURequestAdapterStatus_Unavailable = 0x00000003,
        WGPURequestAdapterStatus_Error = 0x00000004,
        WGPURequestAdapterStatus_Force32 = 0x7FFFFFFF,
    }
}
