namespace Massini.Bindings.Wgpu
{
    public unsafe partial struct WGPUComputePassDescriptor
    {
        public WGPUChainedStruct* nextInChain;

        public WGPUStringView label;

        [NativeTypeName("const WGPUPassTimestampWrites *")]
        public WGPUPassTimestampWrites* timestampWrites;
    }
}
