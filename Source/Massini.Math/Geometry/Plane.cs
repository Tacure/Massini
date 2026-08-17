
using System.Numerics;
using Massini.Math.Primitives;

namespace Massini.Math.Geometry
{
    public partial struct Plane<T>
        where T : unmanaged, IFloatingPointIeee754<T>
    {
        public Vec3<T> p_origin;
        public Vec3<T> p_normal;

        public Plane(Vec3<T> i_origin, Vec3<T> i_normal)
        {
            p_origin = i_origin;
            p_normal = i_normal;
        }
    }
}
