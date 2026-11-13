namespace Massini.Bindings.Wgpu
{
    public unsafe partial struct WGPUBufferBindingLayout
    {
        public WGPUChainedStruct* nextInChain;

        public WGPUBufferBindingType type;

        [NativeTypeName("WGPUBool")]
        public uint hasDynamicOffset;

        [NativeTypeName("uint64_t")]
        public ulong minBindingSize;
    }
}
