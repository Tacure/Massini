namespace Massini.Bindings.Wgpu
{
    public partial struct WGPURequestAdapterWebXROptions
    {
        public WGPUChainedStruct chain;

        [NativeTypeName("WGPUBool")]
        public uint xrCompatible;
    }
}
