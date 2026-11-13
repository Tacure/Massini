namespace Massini.Bindings.Wgpu
{
    public unsafe partial struct WGPUInstanceLimits
    {
        public WGPUChainedStruct* nextInChain;

        [NativeTypeName("size_t")]
        public nuint timedWaitAnyMaxCount;
    }
}
