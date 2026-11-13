namespace Massini.Bindings.Wgpu
{
    public unsafe partial struct WGPUSurfaceSourceWindowsHWND
    {
        public WGPUChainedStruct chain;

        public void* hinstance;

        public void* hwnd;
    }
}
