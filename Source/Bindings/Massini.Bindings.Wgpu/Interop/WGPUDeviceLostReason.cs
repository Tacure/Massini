namespace Massini.Bindings.Wgpu
{
    public enum WGPUDeviceLostReason
    {
        WGPUDeviceLostReason_Unknown = 0x00000001,
        WGPUDeviceLostReason_Destroyed = 0x00000002,
        WGPUDeviceLostReason_CallbackCancelled = 0x00000003,
        WGPUDeviceLostReason_FailedCreation = 0x00000004,
        WGPUDeviceLostReason_Force32 = 0x7FFFFFFF,
    }
}
