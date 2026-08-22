
using System.Numerics;
using Massini.Core.Math.Primitives;

namespace Massini.Core.Math.Geometry
{
    /// <summary>
    /// Defines an axis-aligned bounding rectangle.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct Bounds2D<T>(Vec2<T> i_origin, Vec2<T> i_extent)
        where T : unmanaged, INumber<T>
    {
        public Vec2<T> p_origin = i_origin;
        public Vec2<T> p_extent = i_extent;
    }
}
