namespace Massini.Bindings.Wgpu
{
    public unsafe partial struct WGPUQueueDescriptor
    {
        public WGPUChainedStruct* nextInChain;

        public WGPUStringView label;
    }
}
