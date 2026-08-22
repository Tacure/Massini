
using System.Numerics;
using System.Runtime.InteropServices;
using Massini.Core.Math.Primitives;

namespace Massini.Core.Math.Geometry
{
    /// <summary>
    /// Represents a 3D line segment. Defined by two points.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct Segment3D<T>(Vec3<T> i_pointA, Vec3<T> i_pointB)
        where T : unmanaged, IFloatingPointIeee754<T>
    {
        /// <summary>
        /// One point of the segment.
        /// </summary>
        public Vec3<T> p_pointA = i_pointA;
        /// <summary>
        /// The other point of the segment.
        /// </summary>
        public Vec3<T> p_pointB = i_pointB;
    }

    public static class Segment3D
    {
        extension<T>(Segment3D<T>)
            where T : unmanaged, IFloatingPointIeee754<T>
        {
            /// <summary>
            /// Get a point inside the segment. Inclusive.
            /// </summary>
            /// <remarks>
            /// When delta is zero returns <see cref="p_pointA"/>. 
            /// When delta is the distance between the points returns <see cref="p_pointB"/>.
            /// </remarks>
            /// <param name="i_delta">Positive distance delta. Negative values are clamped to zero.</param>
            /// <returns>A point between the <see cref="p_pointA"/> and <see cref="p_pointB"/>.</returns>
            public static Vec3<T> GetBetween(Segment3D<T> i_segment, T i_delta)
            {
                return Vec3<T>.MoveTowards(i_segment.p_pointA, i_segment.p_pointB, i_delta, out _);
            }
        }
    }
}
