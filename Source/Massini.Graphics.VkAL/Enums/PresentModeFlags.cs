
namespace Massini.Graphics.VkAL.Enums
{
    [Flags]
    public enum PresentModeFlags
    {
        Undefined = 0,
        Fifo = 1 << 0,
        FifoRelaxed = 1 << 1,
        Immediate = 1 << 2,
        Mailbox = 1 << 3,
    }
}
