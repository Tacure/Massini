namespace Massini.Bindings.Wgpu
{
    public unsafe partial struct WGPUCommandBufferDescriptor
    {
        public WGPUChainedStruct* nextInChain;

        public WGPUStringView label;
    }
}
