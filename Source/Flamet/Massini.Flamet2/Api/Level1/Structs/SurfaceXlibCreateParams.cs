 using Massini.Core.Interop.Linux;
 using Massini.Flamet2.Api.Level1.Interfaces;

 namespace Massini.Flamet2.Api.Level1.Structs
{
    public unsafe struct SurfaceXlibCreateParams : INext
    {
        public INext? p_next;
        public required XDisplay* p_ptr_display;
        public required nint p_window;
        
        public readonly INext? Next => p_next;
    }
}