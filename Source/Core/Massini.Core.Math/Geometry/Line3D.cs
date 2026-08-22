
using System.Numerics;
using System.Runtime.InteropServices;
using Massini.Math.Geometry;
using Massini.Math.Primitives;
using Massini.Math.Results;

namespace Massini.Math.Geometry
{
    /// <summary>
    /// This structure defines a line in parametric form: P(t) = Origin + t * Direction.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct Line3D<T>
        where T : unmanaged, IFloatingPointIeee754<T>
    {
        /// <summary>
        /// The origin of the line.
        /// </summary>
        public Vec3<T> p_origin;

        /// <summary>
        /// The direction of the line.
        /// </summary>
        public Vec3<T> p_direction;

        /// <summary>
        /// Create a new instance of <see cref="Line3D{T}"/> with the given origin and direction.
        /// </summary>
        /// <param name="i_origin">The origin of the line.</param>
        /// <param name="i_direction">The direction of the line. Should be normalized.</param>
        public Line3D(Vec3<T> i_origin, Vec3<T> i_direction)
        {
            p_origin = i_origin;
            p_direction = i_direction;
        }
    }

    public static class Line3D
    {
        extension<T>(Line3D<T>)
            where T : unmanaged, IFloatingPointIeee754<T>
        {
            #region Constructor methods.

            /// <summary>
            /// Create a line defined by two points.
            /// </summary>
            public static Line3D<T> CreateLineFromPoints(Vec3<T> i_pointA, Vec3<T> i_pointB)
            {
                Vec3<T> direction = i_pointB - i_pointA;
                return new Line3D<T>(i_pointA, Vec3<T>.Normalize(direction));
            }

            #endregion

            #region Basic methods.

            /// <summary>
            /// Get a point in the line. Positive values go along the direction from the origin.
            /// </summary>
            /// <param name="i_delta">Distance delta from the origin, positive or negative.</param>
            public static Vec3<T> GetPointAlongLine(Line3D<T> i_line, T i_delta)
            {
                return i_line.p_origin + (i_line.p_direction * i_delta);
            }

            #endregion

            #region Raycast methods.

            public static RaycastResult3D<T> Raycast(Line3D<T> i_line, Plane<T> i_plane)
            {
                T a = Vec3<T>.Dot(i_plane.p_origin - i_line.p_origin, i_plane.p_normal);
                T b = Vec3<T>.Dot(i_line.p_direction, i_plane.p_normal);

                // Check if the ray is parallel to the plane.
                if (b == T.Zero)
                {
                     return new(HitResult3D<T>.Miss, HitResult3D<T>.Miss, i_intersect: false, i_inside: false);
                }

                // Get hit distance from the ray origin to the plane.
                T t = a / b;

                // Get the hit point.
                Vec3<T> position = i_line.p_origin + (i_line.p_direction * t);

                // Check if the hit point is behind the ray origin.
                bool isBack = t < T.Zero;

                // Check if the ray is at the positive or negative side relative to the plane normal.
                bool inside = a < T.Zero;

                return new(new(position, isBack), HitResult3D<T>.Miss, i_intersect: true, i_inside: inside);
            }

            public static RaycastResult3D<T> Raycast(Line3D<T> i_line, Sphere<T> i_sphere)
            {
                // Reference: https://www.scratchapixel.com/lessons/3d-basic-rendering/minimal-ray-tracer-rendering-simple-shapes//ray-sphere-intersection.html

                // Radious squared.
                T r2 = i_sphere.p_radius * i_sphere.p_radius;

                // Hypothenuse.
                // Vector from ray origin to sphere center.
                Vec3<T> l = i_sphere.p_origin - i_line.p_origin;
                T lm2 = Vec3<T>.SquaredMagnitude(l);

                // Base.
                // Project l onto ray, aka distance from the ray origin to the closest point on the ray to the sphere origin.
                T tca = Vec3<T>.Dot(l, i_line.p_direction);

                // Height squared.
                // Get the height of the triangle.
                T h2 = lm2 - (tca * tca);

                // Check if the ray hits the sphere.
                if (h2 > r2)
                {
                    return new(HitResult3D<T>.Miss, HitResult3D<T>.Miss, i_intersect: false, i_inside: false);
                }

                // Small triangle base.
                // Hypothenuse -> Sphere radius.
                // Height -> h.
                T thc = Math<T>.Sqrt(r2 - h2);

                T t0 = tca - thc;
                T t1 = tca + thc;

                if (t0 > t1)
                {
                    Math<T>.Swap(ref t0, ref t1);
                }

                // Check if the ray origin is inside the sphere.
                bool inside = lm2 < r2;

                Vec3<T> positionA = i_line.p_origin + (i_line.p_direction * t0);
                bool isBackA = t0 < T.Zero;

                Vec3<T> positionB = i_line.p_origin + (i_line.p_direction * t1);
                bool isBackB = t1 < T.Zero;

                return new(new(positionA, isBackA), new(positionB, isBackB), i_intersect: true, inside);
            }

            #endregion
        }
    }
}
