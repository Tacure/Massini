namespace Massini.Bindings.Wgpu
{
    public enum WGPUQueueWorkDoneStatus
    {
        WGPUQueueWorkDoneStatus_Success = 0x00000001,
        WGPUQueueWorkDoneStatus_CallbackCancelled = 0x00000002,
        WGPUQueueWorkDoneStatus_Error = 0x00000003,
        WGPUQueueWorkDoneStatus_Force32 = 0x7FFFFFFF,
    }
}
