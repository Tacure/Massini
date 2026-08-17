
using System.Numerics;
using Massini.Math.Primitives;

namespace Massini.Math.Geometry
{
    public struct Line2D<T>
        where T : unmanaged, IFloatingPointIeee754<T>
    {
        public Vec2<T> p_origin;
        public Vec2<T> p_direction;

        public Line2D(Vec2<T> i_origin, Vec2<T> i_direction)
        {
            p_origin = i_origin;
            p_direction = i_direction;
        }
    }
}
