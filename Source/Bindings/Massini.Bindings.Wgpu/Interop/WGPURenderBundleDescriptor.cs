namespace Massini.Bindings.Wgpu
{
    public unsafe partial struct WGPURenderBundleDescriptor
    {
        public WGPUChainedStruct* nextInChain;

        public WGPUStringView label;
    }
}
