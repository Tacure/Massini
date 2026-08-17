
namespace Massini.Graphics.VkAL.Enums
{
    [Flags]
    public enum BufferUsageFlags
    {
        None = 0,
        HostVisible = 1 << 0,
        TransferSrc = 1 << 1,
        TransferDst = 1 << 2,
        DeviceAddress = 1 << 3,
    }
}
