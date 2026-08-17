
using System.Numerics;
using Massini.Math.Primitives;

namespace Massini.Math.Geometry
{
    public struct Sphere<T>
        where T : unmanaged, IFloatingPointIeee754<T>
    {
        public Vec3<T> p_origin;
        public T p_radius;

        public Sphere(Vec3<T> i_origin, T i_radius)
        {
            p_origin = i_origin;
            p_radius = i_radius;
        }
    }
}

