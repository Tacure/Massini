
namespace Massini.Graphics.VkAL.Enums
{
    [Flags]
    public enum TextureAspectFlags
    {
        Color = 1 << 0,
        Depth = 1 << 1,
        Stencil = 1 << 2,
    }
}
