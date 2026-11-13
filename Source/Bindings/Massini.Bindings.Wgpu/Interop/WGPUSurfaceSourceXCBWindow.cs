namespace Massini.Bindings.Wgpu
{
    public unsafe partial struct WGPUSurfaceSourceXCBWindow
    {
        public WGPUChainedStruct chain;

        public void* connection;

        [NativeTypeName("uint32_t")]
        public uint window;
    }
}
