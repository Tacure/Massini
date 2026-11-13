namespace Massini.Bindings.Wgpu
{
    public unsafe partial struct WGPUBindGroupDescriptor
    {
        public WGPUChainedStruct* nextInChain;

        public WGPUStringView label;

        [NativeTypeName("WGPUBindGroupLayout")]
        public WGPUBindGroupLayoutImpl* layout;

        [NativeTypeName("size_t")]
        public nuint entryCount;

        [NativeTypeName("const WGPUBindGroupEntry *")]
        public WGPUBindGroupEntry* entries;
    }
}
