
namespace Massini.Graphics.VkAL.Enums
{
    [Flags]
    public enum ShaderStageFlags
    {
        None = 0,
        Vertex = 1 << 0,
        Fragment = 1 << 1,
        Compute = 1 << 2,
        Geometry = 1 << 3,
        TessControl = 1 << 4,
        TessEvaluation = 1 << 5,
    }
}
