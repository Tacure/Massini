namespace Massini.Bindings.Wgpu
{
    public unsafe partial struct WGPUSurfaceSourceXlibWindow
    {
        public WGPUChainedStruct chain;

        public void* display;

        [NativeTypeName("uint64_t")]
        public ulong window;
    }
}
