namespace Massini.Bindings.Wgpu
{
    public partial struct WGPURenderPassMaxDrawCount
    {
        public WGPUChainedStruct chain;

        [NativeTypeName("uint64_t")]
        public ulong maxDrawCount;
    }
}
