
using System.Numerics;
using Massini.Core.Math.Primitives;

namespace Massini.Core.Math.Geometry
{
    /// <summary>
    /// Defines a axis-aligned bounding box.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct Bounds3D<T>(Vec3<T> i_origin, Vec3<T> i_extent)
        where T : unmanaged, INumber<T>
    {
        public Vec3<T> p_origin = i_origin;
        public Vec3<T> p_extent = i_extent;
    }
}
