
namespace Massini.Graphics.VkAL.Enums
{
    [Flags]
    public enum TextureUsageFlags
    {
        None = 0,
        TransferSrc = 1 << 0,
        TransferDst = 1 << 1,
        ColorAttachment = 1 << 2,
        DepthStencilAttachment = 1 << 3,
        InputAttachment = 1 << 4,
        CpuWrite = 1 << 5,
        CpuRead = 1 << 6,
        Sampled = 1 << 7,
        Storage = 1 << 8,
    }
}
