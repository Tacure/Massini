
namespace Massini.Graphics.VkAL.Enums
{
    [Flags]
    public enum QueueUsageFlags
    {
        Unknown = 0,
        Graphics = 1 << 0,
        Compute = 1 << 1,
        Transfer = 1 << 2,
    }
}
