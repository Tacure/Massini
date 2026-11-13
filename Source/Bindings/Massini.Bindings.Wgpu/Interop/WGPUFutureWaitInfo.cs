namespace Massini.Bindings.Wgpu
{
    public partial struct WGPUFutureWaitInfo
    {
        public WGPUFuture future;

        [NativeTypeName("WGPUBool")]
        public uint completed;
    }
}
