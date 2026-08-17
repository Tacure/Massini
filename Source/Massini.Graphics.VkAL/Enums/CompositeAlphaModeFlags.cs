
namespace Massini.Graphics.VkAL.Enums
{
    [Flags]
    public enum CompositeAlphaModeFlags
    {
        Auto = 0,
        Opaque = 1 << 0,
        Premultiplied = 1 << 1,
        Unpremultiplied = 1 << 2,
        Inherit = 1 << 3,
    }
}
