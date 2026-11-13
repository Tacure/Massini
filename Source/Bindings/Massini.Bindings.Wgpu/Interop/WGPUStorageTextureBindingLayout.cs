namespace Massini.Bindings.Wgpu
{
    public unsafe partial struct WGPUStorageTextureBindingLayout
    {
        public WGPUChainedStruct* nextInChain;

        public WGPUStorageTextureAccess access;

        public WGPUTextureFormat format;

        public WGPUTextureViewDimension viewDimension;
    }
}
