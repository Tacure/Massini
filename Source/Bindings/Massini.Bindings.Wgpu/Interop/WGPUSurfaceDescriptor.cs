namespace Massini.Bindings.Wgpu
{
    public unsafe partial struct WGPUSurfaceDescriptor
    {
        public WGPUChainedStruct* nextInChain;

        public WGPUStringView label;
    }
}
