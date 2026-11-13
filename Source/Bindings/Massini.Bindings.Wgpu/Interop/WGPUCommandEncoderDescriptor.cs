namespace Massini.Bindings.Wgpu
{
    public unsafe partial struct WGPUCommandEncoderDescriptor
    {
        public WGPUChainedStruct* nextInChain;

        public WGPUStringView label;
    }
}
