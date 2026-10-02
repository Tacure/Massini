
using Massini.Core.Interop;
using Massini.Flamet2.Api.Level1.Classes;

namespace Massini.Flamet2.Api.Level1.Interfaces
{
    public unsafe interface IBuffer1 : IDisposable
    {
        public BufferInfo GetInfo();
        
        public void SetLabel(string i_label);
        
        public ulong GetDeviceAddress();

        public void WriteBytes(ReadOnlySpan<byte> i_data, MemorySize i_bufferOffset = default);

        public void ReadBytes(Span<byte> i_data, MemorySize i_bufferOffset = default);
    }   
}