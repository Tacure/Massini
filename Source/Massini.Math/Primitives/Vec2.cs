
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.InteropServices;
using Massini.Math.Geometry;

namespace Massini.Math.Primitives
{
    [StructLayout(LayoutKind.Sequential)]
    public partial struct Vec2<T> : IEquatable<Vec2<T>>
        where T : unmanaged, INumber<T>
    {
        public T p_x;
        public T p_y;

        public Vec2(T i_value)
        {
            p_x = i_value;
            p_y = i_value;
        }

        public Vec2(T i_x, T i_y)
        {
            p_x = i_x;
            p_y = i_y;
        }

        /// <inheritdoc/>
        public T this[Index i_index]
        {
            readonly get => i_index.GetOffset(Length) switch
            {
                0 => p_x,
                1 => p_y,
                _ => throw new IndexOutOfRangeException()
            };
            set
            {
                switch (i_index.GetOffset(Length))
                {
                    case 0: p_x = value; break;
                    case 1: p_y = value; break;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }

        public static explicit operator Vector2(Vec2<T> i_other)
            => new(float.CreateTruncating(i_other.p_x), float.CreateTruncating(i_other.p_y));

        public static explicit operator Vec2<T>(Vector2 i_other)
            => new(T.CreateTruncating(i_other.X), T.CreateTruncating(i_other.Y));

        public static Vec2<T> operator -(Vec2<T> value)
        {
            return new(-value.p_x, -value.p_y);
        }

        public static Vec2<T> operator +(Vec2<T> i_vector, T i_scalar)
        {
            return new(i_vector.p_x + i_scalar, i_vector.p_y + i_scalar);
        }

        public static Vec2<T> operator +(T i_scalar, Vec2<T> i_vector)
        {
            return new(i_scalar + i_vector.p_x, i_scalar + i_vector.p_y);
        }

        public static Vec2<T> operator +(Vec2<T> left, Vec2<T> right)
        {
            return new(left.p_x + right.p_x, left.p_y + right.p_y);
        }

        public static Vec2<T> operator -(Vec2<T> i_vector, T i_scalar)
        {
            return new(i_vector.p_x - i_scalar, i_vector.p_y - i_scalar);
        }

        public static Vec2<T> operator -(T i_scalar, Vec2<T> i_vector)
        {
            return new(i_scalar - i_vector.p_x, i_scalar - i_vector.p_y);
        }

        public static Vec2<T> operator -(Vec2<T> left, Vec2<T> right)
        {
            return new(left.p_x - right.p_x, left.p_y - right.p_y);
        }

        public static Vec2<T> operator *(Vec2<T> i_vector, T i_scalar)
        {
            return new(i_vector.p_x * i_scalar, i_vector.p_y * i_scalar);
        }

        public static Vec2<T> operator *(T i_scalar, Vec2<T> i_vector)
        {
            return new(i_scalar * i_vector.p_x, i_scalar * i_vector.p_y);
        }

        public static Vec2<T> operator *(Vec2<T> left, Vec2<T> right)
        {
            return new(left.p_x * right.p_x, left.p_y * right.p_y);
        }

        public static Vec2<T> operator /(Vec2<T> i_vector, T i_scalar)
        {
            return new(i_vector.p_x / i_scalar, i_vector.p_y / i_scalar);
        }

        public static Vec2<T> operator /(T i_scalar, Vec2<T> i_vector)
        {
            return new(i_scalar / i_vector.p_x, i_scalar / i_vector.p_y);
        }

        public static Vec2<T> operator /(Vec2<T> left, Vec2<T> right)
        {
            return new(left.p_x / right.p_x, left.p_y / right.p_y);
        }

        public static bool operator ==(Vec2<T> left, Vec2<T> right)
        {
            return left.p_x == right.p_x && left.p_y == right.p_y;
        }

        public static bool operator !=(Vec2<T> left, Vec2<T> right)
        {
            return left.p_x != right.p_x || left.p_y != right.p_y;
        }

        public static Vec2<T> Zero => new(T.Zero);

        public static Vec2<T> One => new(T.One);

        /// <inheritdoc/>
        public static Vec2<T> AdditiveIdentity => Zero;

        public static Vec2<T> UnitX => new(T.One, T.Zero);

        public static Vec2<T> UnitY => new(T.Zero, T.One);

        public readonly int Length => 2;

        public T X { readonly get => p_x; set => p_x = value; }
        public T Y { readonly get => p_y; set => p_y = value; }

        public readonly bool Equals(Vec2<T> i_other)
        {
            return this == i_other;
        }

        public readonly override bool Equals([NotNullWhen(true)] object? i_obj)
        {
            if (i_obj is Vec2<T> other)
            {
                return this == other;
            }
            return false;
        }

        public readonly override int GetHashCode()
        {
            return HashCode.Combine(p_x, p_y);
        }

        public readonly override string ToString()
        {
            return $"[X: {p_x} Y: {p_y}]";
        }
    }

    public partial struct Vec2<T>
    {
        #region Accessors.

        public T Width
        {
            readonly get => p_x;
            set => p_x = value;
        }

        public T Height
        {
            readonly get => p_y;
            set => p_y = value;
        }

        #endregion

        #region Swizzle methods.

        public readonly Vec2<T> XX => new(p_x, p_x);
        public Vec2<T> XY { readonly get => new(p_x, p_y); set { p_x = value.p_x; p_y = value.p_y; } }
        public Vec2<T> YX { readonly get => new(p_y, p_x); set { p_y = value.p_x; p_x = value.p_y; } }
        public readonly Vec2<T> YY => new(p_y, p_y);

        public readonly Vec3<T> XXX => new(p_x, p_x, p_x);
        public readonly Vec3<T> XXY => new(p_x, p_x, p_y);
        public readonly Vec3<T> XYX => new(p_x, p_y, p_x);
        public readonly Vec3<T> XYY => new(p_x, p_y, p_y);
        public readonly Vec3<T> YXX => new(p_y, p_x, p_x);
        public readonly Vec3<T> YXY => new(p_y, p_x, p_y);
        public readonly Vec3<T> YYX => new(p_y, p_y, p_x);
        public readonly Vec3<T> YYY => new(p_y, p_y, p_y);

        public readonly Vec4<T> XXXX => new(p_x, p_x, p_x, p_x);
        public readonly Vec4<T> XXXY => new(p_x, p_x, p_x, p_y);
        public readonly Vec4<T> XXYX => new(p_x, p_x, p_y, p_x);
        public readonly Vec4<T> XXYY => new(p_x, p_x, p_y, p_y);
        public readonly Vec4<T> XYXX => new(p_x, p_y, p_x, p_x);
        public readonly Vec4<T> XYXY => new(p_x, p_y, p_x, p_y);
        public readonly Vec4<T> XYYX => new(p_x, p_y, p_y, p_x);
        public readonly Vec4<T> XYYY => new(p_x, p_y, p_y, p_y);
        public readonly Vec4<T> YXXX => new(p_y, p_x, p_x, p_x);
        public readonly Vec4<T> YXXY => new(p_y, p_x, p_x, p_y);
        public readonly Vec4<T> YXYX => new(p_y, p_x, p_y, p_x);
        public readonly Vec4<T> YXYY => new(p_y, p_x, p_y, p_y);
        public readonly Vec4<T> YYXX => new(p_y, p_y, p_x, p_x);
        public readonly Vec4<T> YYXY => new(p_y, p_y, p_x, p_y);
        public readonly Vec4<T> YYYX => new(p_y, p_y, p_y, p_x);
        public readonly Vec4<T> YYYY => new(p_y, p_y, p_y, p_y);

        #endregion

        #region Basic methods.

        /// <summary>
        /// Returns a vector with the components reversed.
        /// </summary>
        /// <returns></returns>
        public static Vec2<T> Reverse(Vec2<T> i_vector)
        {
            return i_vector * -T.One;
        }

        /// <summary>
        /// Returns the squared Euclidean magnitude of the given vector.
        /// </summary>
        /// <returns></returns>
        public static T SquaredMagnitude(Vec2<T> i_vector)
        {
            return (i_vector.p_x * i_vector.p_x) + (i_vector.p_y * i_vector.p_y);
        }

        public static Vec2<T> PerpendicularClockwise(Vec2<T> i_vector)
        {
            return new(i_vector.p_y, -i_vector.p_x);
        }

        public static Vec2<T> PerpendicularCounterClockwise(Vec2<T> i_vector)
        {
            return new(-i_vector.p_y, i_vector.p_x);
        }

        #endregion

        #region Comparison methods.

        /// <summary>
        /// Returns whether the two given vectors are nearly equal.
        /// </summary>
        public static bool NearlyEqual(Vec2<T> i_vector, Vec2<T> i_vec2, T i_delta)
        {
            return Math<T>.NearlyEqual(i_vector.p_x, i_vec2.p_x, i_delta) &&
                Math<T>.NearlyEqual(i_vector.p_y, i_vec2.p_y, i_delta);
        }

        #endregion

        #region Product methods.

        /// <summary>
        /// Returns the dot product of the two given vectors.
        /// </summary>
        public static T Dot(Vec2<T> i_vector, Vec2<T> i_vec2)
        {
            return (i_vector.p_x * i_vec2.p_x) + (i_vector.p_y * i_vec2.p_y);
        }

        /// <summary>
        /// Returns a single value representing the Z component of the cross product of the two given vectors.
        /// </summary>
        public static T Cross(Vec2<T> i_vector, Vec2<T> i_vec2)
        {
            return (i_vector.p_x * i_vec2.p_y) - (i_vector.p_y * i_vec2.p_x);
        }

        #endregion

        #region Reflection methods.

        /// <summary>
        /// Returns a copy of the given vector reflected across the given normal.
        /// </summary>
        public static Vec2<T> Reflect(Vec2<T> i_vector, Vec2<T> i_normal)
        {
            return i_vector - (Math<T>.Two * Dot(i_vector, i_normal) * i_normal);
        }

        /// <summary>
        /// Returns a copy of the given vector reflected across the X axis.
        /// </summary>
        public static Vec2<T> MirrorAcrossXAxis(Vec2<T> i_vector)
        {
            return new(-i_vector.p_x, i_vector.p_y);
        }

        /// <summary>
        /// Returns a copy of the given vector reflected across the Y axis.
        /// </summary>
        public static Vec2<T> MirrorAcrossYAxis(Vec2<T> i_vector)
        {
            return new(i_vector.p_x, -i_vector.p_y);
        }

        /// <summary>
        /// Returns a copy of the given vector reflected across the given point.
        /// </summary>
        public static Vec2<T> MirrorAcrossPoint(Vec2<T> i_vector, Vec2<T> i_point)
        {
            return (Math<T>.Two * i_point) - i_vector;
        }

        #endregion
    }

    public static class Vec2
    {
        extension<T>(Vec2<T>)
            where T : unmanaged, IFloatingPointIeee754<T>
        {
            #region Basic methods.

            public static Vec2<T> Floor(Vec2<T> i_vector)
            {
                return new(Math<T>.Floor(i_vector.p_x), Math<T>.Floor(i_vector.p_y));
            }

            public static Vec2<T> Fract(Vec2<T> i_vector)
            {
                return new(Math<T>.Fract(i_vector.p_x), Math<T>.Fract(i_vector.p_y));
            }

            /// <summary>
            /// Returns the Euclidean magnitude of the given vector.
            /// </summary>
            /// <returns>The magnitude of the vector.</returns>
            public static T Magnitude(Vec2<T> i_vector)
            {
                return Math<T>.Sqrt((i_vector.p_x * i_vector.p_x) + (i_vector.p_y * i_vector.p_y));
            }

            /// <summary>
            /// Returns a copy of the given vector with the new magnitude.
            /// </summary>
            /// <param name="i_magnitude"></param>
            /// <returns></returns>
            public static Vec2<T> Resize(Vec2<T> i_vector, T i_magnitude)
            {
                return i_vector * (i_magnitude / Magnitude(i_vector));
            }

            /// <summary>
            /// Returns a normalized copy of the given vector.
            /// </summary>
            public static Vec2<T> Normalize(Vec2<T> i_vector)
            {
                T mag = Magnitude(i_vector);
                return i_vector / mag;
            }

            #endregion

            #region Interpolation methods.

            /// <summary>
            /// Linear interpolation.
            /// </summary>
            public static Vec2<T> Lerp(Vec2<T> i_vector, Vec2<T> i_to, T i_t)
            {
                return new()
                {
                    p_x = Math<T>.Lerp(i_vector.p_x, i_to.p_x, i_t),
                    p_y = Math<T>.Lerp(i_vector.p_y, i_to.p_y, i_t),
                };
            }

            /// <summary>
            /// Normalized linear interpolation.
            /// </summary>
            public static Vec2<T> NLerp(Vec2<T> i_vector, Vec2<T> i_vec2, T i_t)
            {
                return Normalize(Lerp(i_vector, i_vec2, i_t));
            }

            /// <summary>
            /// Spherical linear interpolation.
            /// </summary>
            public static Vec2<T> SLerp(Vec2<T> i_vector, Vec2<T> i_vec2, T i_t)
            {
                // Reference: https://keithmaggio.wordpress.com/2011/02/15/math-magician-lerp-slerp-and-nlerp/

                // Dot product - the cosine of the angle between 2 vectors.
                T dot = Vec2<T>.Dot(i_vector, i_vec2);
                // Clamp it to be in the range of Acos()
                dot = Math<T>.Clamp(dot, -T.One, T.One);
                // Acos(dot) returns the angle between start and end,
                // And multiplying that by percent returns the angle between
                // start and the final result.
                Rad<T> theta = Rad<T>.Acos(dot) * i_t;
                Vec2<T> relativeVec = i_vec2 - (i_vector * dot);
                relativeVec = Normalize(relativeVec);
                // Orthonormal basis
                // The final result.
                return (i_vector * Rad<T>.Cos(theta)) + (relativeVec * Rad<T>.Sin(theta));
            }

            #endregion

            #region Refraction methods.

            /// <summary>
            /// Refracts a vector using Snell's Law.
            /// </summary>
            public static Vec2<T> Refract(Vec2<T> i_vector, Vec2<T> i_normal, T i_refractionIndex1, T i_refractionIndex2)
            {
                // Reference: https://asawicki.info/news_1301_reflect_and_refract_functions.html

                if (i_refractionIndex1 == i_refractionIndex2) return i_vector;

                T N_dot_I = Vec2<T>.Dot(i_normal, i_vector);
                T eta = i_refractionIndex1 / i_refractionIndex2;
                T k = T.One - (eta * eta * (T.One - (N_dot_I * N_dot_I)));
                if (k < T.Zero)
                {
                    return Vec2<T>.Zero;
                }
                return (eta * i_vector) - (((eta * N_dot_I) + Math<T>.Sqrt(k)) * i_normal);
            }

            #endregion

            #region Rotation methods.

            /// <summary>
            /// Returns the angle in radians of the given direction vector.
            /// </summary>
            public static Rad<T> DirectionToRadians(Vec2<T> i_vector)
            {
                return Rad<T>.Atan2(i_vector.p_y, i_vector.p_x);
            }

            /// <summary>
            /// Returns a copy of the given vector rotated by an angle in radians.
            /// </summary>
            public static Vec2<T> RotateVector(Vec2<T> i_vector, Rad<T> i_radians)
            {
                T angleCos = Rad<T>.Cos(i_radians);
                T angleSin = Rad<T>.Sin(i_radians);
                return new((angleCos * i_vector.p_x) - (angleSin * i_vector.p_y), (angleSin * i_vector.p_x) + (angleCos * i_vector.p_y));
            }

            #endregion

            #region Distance methods.

            /// <summary>
            /// Distance between two points.
            /// </summary>
            public static T Distance(Vec2<T> i_vector, Vec2<T> i_point2)
            {
                return Math<T>.Sqrt(
                    ((i_point2.p_x - i_vector.p_x) * (i_point2.p_x - i_vector.p_x)) +
                    ((i_point2.p_y - i_vector.p_y) * (i_point2.p_y - i_vector.p_y)));
            }

            #endregion

            #region Movement methods.

            /// <summary>
            /// Move towards a target.
            /// </summary>
            /// <param name="i_target">The target point.</param>
            /// <param name="i_step">Positive step size.</param>
            public static Vec2<T> MoveTowards(Vec2<T> i_vector, Vec2<T> i_target, T i_step)
            {
                // Direction vector (target - current)
                T deltaX = i_target.X - i_vector.X;
                T deltaY = i_target.Y - i_vector.Y;

                Vec2<T> direction = new(deltaX, deltaY);

                // Distance between the current point and the target.
                T dist = Magnitude(direction);

                // Check if the step is greater than the distance to the target
                // or if the current point is already at the target (distance is zero).
                if (dist <= i_step || dist == T.Zero)
                {
                    return i_target;
                }

                // Normalized direction * step.
                return new Vec2<T>(
                    i_vector.X + ((deltaX / dist) * i_step),
                    i_vector.Y + ((deltaY / dist) * i_step)
                );
            }

            #endregion

            #region Projection methods.

            /// <summary>
            /// Projects a vector onto a line.
            /// </summary>
            public static Vec2<T> Project(Vec2<T> i_vector, Line2D<T> i_line)
            {
                Vec2<T> v = i_vector - i_line.p_origin;
                T d = Vec2<T>.Dot(v, i_line.p_direction);
                return i_line.p_origin + (i_line.p_direction * d);
            }

            #endregion
        }
    }
}
