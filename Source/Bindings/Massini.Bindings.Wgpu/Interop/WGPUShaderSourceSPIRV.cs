namespace Massini.Bindings.Wgpu
{
    public unsafe partial struct WGPUShaderSourceSPIRV
    {
        public WGPUChainedStruct chain;

        [NativeTypeName("uint32_t")]
        public uint codeSize;

        [NativeTypeName("const uint32_t *")]
        public uint* code;
    }
}
