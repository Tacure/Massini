
using System.Numerics;
using Massini.Math.Primitives;

namespace Massini.Math.Geometry
{
    public struct Segment2D<T>(Vec2<T> i_pointA, Vec2<T> i_pointB)
        where T : unmanaged, IFloatingPointIeee754<T>
    {
        /// <summary>
        /// One point of the segment.
        /// </summary>
        public Vec2<T> p_pointA = i_pointA;
        /// <summary>
        /// The other point of the segment.
        /// </summary>
        public Vec2<T> p_pointB = i_pointB;
    }
}
