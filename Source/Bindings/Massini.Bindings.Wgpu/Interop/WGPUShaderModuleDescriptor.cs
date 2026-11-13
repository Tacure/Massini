namespace Massini.Bindings.Wgpu
{
    public unsafe partial struct WGPUShaderModuleDescriptor
    {
        public WGPUChainedStruct* nextInChain;

        public WGPUStringView label;
    }
}
