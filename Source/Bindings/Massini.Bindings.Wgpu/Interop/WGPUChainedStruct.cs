namespace Massini.Bindings.Wgpu
{
    public unsafe partial struct WGPUChainedStruct
    {
        [NativeTypeName("struct WGPUChainedStruct *")]
        public WGPUChainedStruct* next;

        public WGPUSType sType;
    }
}
