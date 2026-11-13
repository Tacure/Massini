namespace Massini.Bindings.Wgpu
{
    public partial struct WGPUStencilFaceState
    {
        public WGPUCompareFunction compare;

        public WGPUStencilOperation failOp;

        public WGPUStencilOperation depthFailOp;

        public WGPUStencilOperation passOp;
    }
}
