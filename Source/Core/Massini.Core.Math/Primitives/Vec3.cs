
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.InteropServices;
using Massini.Core.Math.Geometry;

namespace Massini.Core.Math.Primitives
{
    [StructLayout(LayoutKind.Sequential)]
    public partial struct Vec3<T> : IEquatable<Vec3<T>>
        where T : unmanaged, INumber<T>
    {
        public T p_x;
        public T p_y;
        public T p_z;

        public Vec3(T i_value)
        {
            p_x = i_value;
            p_y = i_value;
            p_z = i_value;
        }

        public Vec3(T i_x, T i_y, T i_z)
        {
            p_x = i_x;
            p_y = i_y;
            p_z = i_z;
        }

        public Vec3(T i_x, Vec2<T> i_yz)
        {
            p_x = i_x;
            p_y = i_yz.p_x;
            p_z = i_yz.p_y;
        }

        /// <inheritdoc/>
        public T this[Index i_index]
        {
            readonly get => i_index.GetOffset(Length) switch
            {
                0 => p_x,
                1 => p_y,
                2 => p_z,
                _ => throw new IndexOutOfRangeException()
            };
            set
            {
                switch (i_index.GetOffset(Length))
                {
                    case 0: p_x = value; break;
                    case 1: p_y = value; break;
                    case 2: p_z = value; break;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }

        public static explicit operator Vector3(Vec3<T> i_other)
            => new(float.CreateTruncating(i_other.p_x), float.CreateTruncating(i_other.p_y), float.CreateTruncating(i_other.p_z));

        public static explicit operator Vec3<T>(Vector3 i_other)
            => new(T.CreateTruncating(i_other.X), T.CreateTruncating(i_other.Y), T.CreateTruncating(i_other.Z));

        public static Vec3<T> operator -(Vec3<T> value)
        {
            return new(-value.p_x, -value.p_y, -value.p_z);
        }

        public static Vec3<T> operator +(Vec3<T> i_vector, T i_scalar)
        {
            return new(i_vector.p_x + i_scalar, i_vector.p_y + i_scalar, i_vector.p_z + i_scalar);
        }

        public static Vec3<T> operator +(T i_scalar, Vec3<T> i_vector)
        {
            return new(i_scalar + i_vector.p_x, i_scalar + i_vector.p_y, i_scalar + i_vector.p_z);
        }

        public static Vec3<T> operator +(Vec3<T> left, Vec3<T> right)
        {
            return new(left.p_x + right.p_x, left.p_y + right.p_y, left.p_z + right.p_z);
        }

        public static Vec3<T> operator -(Vec3<T> i_vector, T i_scalar)
        {
            return new(i_vector.p_x - i_scalar, i_vector.p_y - i_scalar, i_vector.p_z - i_scalar);
        }

        public static Vec3<T> operator -(T i_scalar, Vec3<T> i_vector)
        {
            return new(i_scalar - i_vector.p_x, i_scalar - i_vector.p_y, i_scalar - i_vector.p_z);
        }

        public static Vec3<T> operator -(Vec3<T> left, Vec3<T> right)
        {
            return new(left.p_x - right.p_x, left.p_y - right.p_y, left.p_z - right.p_z);
        }

        public static Vec3<T> operator *(Vec3<T> i_vector, T i_scalar)
        {
            return new(i_vector.p_x * i_scalar, i_vector.p_y * i_scalar, i_vector.p_z * i_scalar);
        }

        public static Vec3<T> operator *(T i_scalar, Vec3<T> i_vector)
        {
            return new(i_scalar * i_vector.p_x, i_scalar * i_vector.p_y, i_scalar * i_vector.p_z);
        }

        public static Vec3<T> operator *(Vec3<T> left, Vec3<T> right)
        {
            return new(left.p_x * right.p_x, left.p_y * right.p_y, left.p_z * right.p_z);
        }

        public static Vec3<T> operator /(Vec3<T> i_vector, T i_scalar)
        {
            return new(i_vector.p_x / i_scalar, i_vector.p_y / i_scalar, i_vector.p_z / i_scalar);
        }

        public static Vec3<T> operator /(T i_scalar, Vec3<T> i_vector)
        {
            return new(i_scalar / i_vector.p_x, i_scalar / i_vector.p_y, i_scalar / i_vector.p_z);
        }

        public static Vec3<T> operator /(Vec3<T> left, Vec3<T> right)
        {
            return new(left.p_x / right.p_x, left.p_y / right.p_y, left.p_z / right.p_z);
        }

        public static bool operator ==(Vec3<T> left, Vec3<T> right)
        {
            return left.p_x == right.p_x && left.p_y == right.p_y && left.p_z == right.p_z;
        }

        public static bool operator !=(Vec3<T> left, Vec3<T> right)
        {
            return left.p_x != right.p_x || left.p_y != right.p_y || left.p_z != right.p_z;
        }

        public static Vec3<T> Zero => new(T.Zero);

        public static Vec3<T> One => new(T.One);

        /// <inheritdoc/>
        public static Vec3<T> AdditiveIdentity => Zero;

        public static Vec3<T> UnitX => new(T.One, T.Zero, T.Zero);

        public static Vec3<T> UnitY => new(T.Zero, T.One, T.Zero);

        public static Vec3<T> UnitZ => new(T.Zero, T.Zero, T.One);

        public readonly int Length => 3;

        public T X { readonly get => p_x; set => p_x = value; }
        public T Y { readonly get => p_y; set => p_y = value; }
        public T Z { readonly get => p_z; set => p_z = value; }

        public readonly bool Equals(Vec3<T> i_other)
        {
            return this == i_other;
        }

        public readonly override bool Equals([NotNullWhen(true)] object? i_obj)
        {
            if (i_obj is Vec3<T> other)
            {
                return this == other;
            }
            return false;
        }

        public readonly override int GetHashCode()
        {
            return HashCode.Combine(p_x, p_y, p_z);
        }

        public readonly override string ToString()
        {
            return $"[X: {p_x} Y: {p_y} Z: {p_z}]";
        }
    }

    public partial struct Vec3<T>
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

        public T Depth
        {
            readonly get => p_z;
            set => p_z = value;
        }

        #endregion

        #region Swizzle methods.

        public readonly Vec2<T> XX => new(p_x, p_x);
        public Vec2<T> XY { readonly get => new(p_x, p_y); set { p_x = value.p_x; p_y = value.p_y; } }
        public Vec2<T> XZ { readonly get => new(p_x, p_z); set { p_x = value.p_x; p_z = value.p_y; } }
        public Vec2<T> YX { readonly get => new(p_y, p_x); set { p_y = value.p_x; p_x = value.p_y; } }
        public readonly Vec2<T> YY => new(p_y, p_y);
        public Vec2<T> YZ { readonly get => new(p_y, p_z); set { p_y = value.p_x; p_z = value.p_y; } }
        public Vec2<T> ZX { readonly get => new(p_z, p_x); set { p_z = value.p_x; p_x = value.p_y; } }
        public Vec2<T> ZY { readonly get => new(p_z, p_y); set { p_z = value.p_x; p_y = value.p_y; } }
        public readonly Vec2<T> ZZ => new(p_z, p_z);

        public readonly Vec3<T> XXX => new(p_x, p_x, p_x);
        public readonly Vec3<T> XXY => new(p_x, p_x, p_y);
        public readonly Vec3<T> XXZ => new(p_x, p_x, p_z);
        public readonly Vec3<T> XYX => new(p_x, p_y, p_x);
        public readonly Vec3<T> XYY => new(p_x, p_y, p_y);
        public Vec3<T> XYZ { readonly get => new(p_x, p_y, p_z); set { p_x = value.p_x; p_y = value.p_y; p_z = value.p_z; } }
        public readonly Vec3<T> XZX => new(p_x, p_z, p_x);
        public Vec3<T> XZY { readonly get => new(p_x, p_z, p_y); set { p_x = value.p_x; p_z = value.p_y; p_y = value.p_z; } }
        public readonly Vec3<T> XZZ => new(p_x, p_z, p_z);
        public readonly Vec3<T> YXX => new(p_y, p_x, p_x);
        public readonly Vec3<T> YXY => new(p_y, p_x, p_y);
        public Vec3<T> YXZ { readonly get => new(p_y, p_x, p_z); set { p_y = value.p_x; p_x = value.p_y; p_z = value.p_z; } }
        public readonly Vec3<T> YYX => new(p_y, p_y, p_x);
        public readonly Vec3<T> YYY => new(p_y, p_y, p_y);
        public readonly Vec3<T> YYZ => new(p_y, p_y, p_z);
        public Vec3<T> YZX { readonly get => new(p_y, p_z, p_x); set { p_y = value.p_x; p_z = value.p_y; p_x = value.p_z; } }
        public readonly Vec3<T> YZY => new(p_y, p_z, p_y);
        public readonly Vec3<T> YZZ => new(p_y, p_z, p_z);
        public readonly Vec3<T> ZXX => new(p_z, p_x, p_x);
        public Vec3<T> ZXY { readonly get => new(p_z, p_x, p_y); set { p_z = value.p_x; p_x = value.p_y; p_y = value.p_z; } }
        public readonly Vec3<T> ZXZ => new(p_z, p_x, p_z);
        public Vec3<T> ZYX { readonly get => new(p_z, p_y, p_x); set { p_z = value.p_x; p_y = value.p_y; p_x = value.p_z; } }
        public readonly Vec3<T> ZYY => new(p_z, p_y, p_y);
        public readonly Vec3<T> ZYZ => new(p_z, p_y, p_z);
        public readonly Vec3<T> ZZX => new(p_z, p_z, p_x);
        public readonly Vec3<T> ZZY => new(p_z, p_z, p_y);
        public readonly Vec3<T> ZZZ => new(p_z, p_z, p_z);

        public readonly Vec4<T> XXXX => new(p_x, p_x, p_x, p_x);
        public readonly Vec4<T> XXXY => new(p_x, p_x, p_x, p_y);
        public readonly Vec4<T> XXXZ => new(p_x, p_x, p_x, p_z);
        public readonly Vec4<T> XXYX => new(p_x, p_x, p_y, p_x);
        public readonly Vec4<T> XXYY => new(p_x, p_x, p_y, p_y);
        public readonly Vec4<T> XXYZ => new(p_x, p_x, p_y, p_z);
        public readonly Vec4<T> XXZX => new(p_x, p_x, p_z, p_x);
        public readonly Vec4<T> XXZY => new(p_x, p_x, p_z, p_y);
        public readonly Vec4<T> XXZZ => new(p_x, p_x, p_z, p_z);
        public readonly Vec4<T> XYXX => new(p_x, p_y, p_x, p_x);
        public readonly Vec4<T> XYXY => new(p_x, p_y, p_x, p_y);
        public readonly Vec4<T> XYXZ => new(p_x, p_y, p_x, p_z);
        public readonly Vec4<T> XYYX => new(p_x, p_y, p_y, p_x);
        public readonly Vec4<T> XYYY => new(p_x, p_y, p_y, p_y);
        public readonly Vec4<T> XYYZ => new(p_x, p_y, p_y, p_z);
        public readonly Vec4<T> XYZX => new(p_x, p_y, p_z, p_x);
        public readonly Vec4<T> XYZY => new(p_x, p_y, p_z, p_y);
        public readonly Vec4<T> XYZZ => new(p_x, p_y, p_z, p_z);
        public readonly Vec4<T> XZXX => new(p_x, p_z, p_x, p_x);
        public readonly Vec4<T> XZXY => new(p_x, p_z, p_x, p_y);
        public readonly Vec4<T> XZXZ => new(p_x, p_z, p_x, p_z);
        public readonly Vec4<T> XZYX => new(p_x, p_z, p_y, p_x);
        public readonly Vec4<T> XZYY => new(p_x, p_z, p_y, p_y);
        public readonly Vec4<T> XZYZ => new(p_x, p_z, p_y, p_z);
        public readonly Vec4<T> XZZX => new(p_x, p_z, p_z, p_x);
        public readonly Vec4<T> XZZY => new(p_x, p_z, p_z, p_y);
        public readonly Vec4<T> XZZZ => new(p_x, p_z, p_z, p_z);
        public readonly Vec4<T> YXXX => new(p_y, p_x, p_x, p_x);
        public readonly Vec4<T> YXXY => new(p_y, p_x, p_x, p_y);
        public readonly Vec4<T> YXXZ => new(p_y, p_x, p_x, p_z);
        public readonly Vec4<T> YXYX => new(p_y, p_x, p_y, p_x);
        public readonly Vec4<T> YXYY => new(p_y, p_x, p_y, p_y);
        public readonly Vec4<T> YXYZ => new(p_y, p_x, p_y, p_z);
        public readonly Vec4<T> YXZX => new(p_y, p_x, p_z, p_x);
        public readonly Vec4<T> YXZY => new(p_y, p_x, p_z, p_y);
        public readonly Vec4<T> YXZZ => new(p_y, p_x, p_z, p_z);
        public readonly Vec4<T> YYXX => new(p_y, p_y, p_x, p_x);
        public readonly Vec4<T> YYXY => new(p_y, p_y, p_x, p_y);
        public readonly Vec4<T> YYXZ => new(p_y, p_y, p_x, p_z);
        public readonly Vec4<T> YYYX => new(p_y, p_y, p_y, p_x);
        public readonly Vec4<T> YYYY => new(p_y, p_y, p_y, p_y);
        public readonly Vec4<T> YYYZ => new(p_y, p_y, p_y, p_z);
        public readonly Vec4<T> YYZX => new(p_y, p_y, p_z, p_x);
        public readonly Vec4<T> YYZY => new(p_y, p_y, p_z, p_y);
        public readonly Vec4<T> YYZZ => new(p_y, p_y, p_z, p_z);
        public readonly Vec4<T> YZXX => new(p_y, p_z, p_x, p_x);
        public readonly Vec4<T> YZXY => new(p_y, p_z, p_x, p_y);
        public readonly Vec4<T> YZXZ => new(p_y, p_z, p_x, p_z);
        public readonly Vec4<T> YZYX => new(p_y, p_z, p_y, p_x);
        public readonly Vec4<T> YZYY => new(p_y, p_z, p_y, p_y);
        public readonly Vec4<T> YZYZ => new(p_y, p_z, p_y, p_z);
        public readonly Vec4<T> YZZX => new(p_y, p_z, p_z, p_x);
        public readonly Vec4<T> YZZY => new(p_y, p_z, p_z, p_y);
        public readonly Vec4<T> YZZZ => new(p_y, p_z, p_z, p_z);
        public readonly Vec4<T> ZXXX => new(p_z, p_x, p_x, p_x);
        public readonly Vec4<T> ZXXY => new(p_z, p_x, p_x, p_y);
        public readonly Vec4<T> ZXXZ => new(p_z, p_x, p_x, p_z);
        public readonly Vec4<T> ZXYX => new(p_z, p_x, p_y, p_x);
        public readonly Vec4<T> ZXYY => new(p_z, p_x, p_y, p_y);
        public readonly Vec4<T> ZXYZ => new(p_z, p_x, p_y, p_z);
        public readonly Vec4<T> ZXZX => new(p_z, p_x, p_z, p_x);
        public readonly Vec4<T> ZXZY => new(p_z, p_x, p_z, p_y);
        public readonly Vec4<T> ZXZZ => new(p_z, p_x, p_z, p_z);
        public readonly Vec4<T> ZYXX => new(p_z, p_y, p_x, p_x);
        public readonly Vec4<T> ZYXY => new(p_z, p_y, p_x, p_y);
        public readonly Vec4<T> ZYXZ => new(p_z, p_y, p_x, p_z);
        public readonly Vec4<T> ZYYX => new(p_z, p_y, p_y, p_x);
        public readonly Vec4<T> ZYYY => new(p_z, p_y, p_y, p_y);
        public readonly Vec4<T> ZYYZ => new(p_z, p_y, p_y, p_z);
        public readonly Vec4<T> ZYZX => new(p_z, p_y, p_z, p_x);
        public readonly Vec4<T> ZYZY => new(p_z, p_y, p_z, p_y);
        public readonly Vec4<T> ZYZZ => new(p_z, p_y, p_z, p_z);
        public readonly Vec4<T> ZZXX => new(p_z, p_z, p_x, p_x);
        public readonly Vec4<T> ZZXY => new(p_z, p_z, p_x, p_y);
        public readonly Vec4<T> ZZXZ => new(p_z, p_z, p_x, p_z);
        public readonly Vec4<T> ZZYX => new(p_z, p_z, p_y, p_x);
        public readonly Vec4<T> ZZYY => new(p_z, p_z, p_y, p_y);
        public readonly Vec4<T> ZZYZ => new(p_z, p_z, p_y, p_z);
        public readonly Vec4<T> ZZZX => new(p_z, p_z, p_z, p_x);
        public readonly Vec4<T> ZZZY => new(p_z, p_z, p_z, p_y);
        public readonly Vec4<T> ZZZZ => new(p_z, p_z, p_z, p_z);

        #endregion

        #region Basic Methods

        /// <summary>
        /// Returns a vector with the components reversed.
        /// </summary>
        public static Vec3<T> Reverse(Vec3<T> i_vector)
        {
            return i_vector * -T.One;
        }

        #endregion

        #region Comparison methods.

        /// <summary>
        /// Returns true if the two vectors are nearly equal.
        /// </summary>
        public static bool NearlyEqual(Vec3<T> i_left, Vec3<T> i_right, T i_delta)
        {
            return Math<T>.NearlyEqual(i_left.p_x, i_right.p_x, i_delta) &&
                Math<T>.NearlyEqual(i_left.p_y, i_right.p_y, i_delta) &&
                Math<T>.NearlyEqual(i_left.p_z, i_right.p_z, i_delta);
        }

        #endregion

        #region Product methods.

        /// <summary>
        /// Returns the dot product of the two given vectors.
        /// </summary>
        /// <param name="i_vec2">The second vector.</param>
        /// <returns>The dot product of <paramref name="i_vec"/> and <paramref name="i_vec2"/>.</returns>
        public static T Dot(Vec3<T> i_vector, Vec3<T> i_vec2)
        {
            return (i_vector.p_x * i_vec2.p_x) + (i_vector.p_y * i_vec2.p_y) + (i_vector.p_z * i_vec2.p_z);
        }

        /// <summary>
        /// Returns the cross product of the two given vectors.
        /// </summary>
        /// <param name="i_vec2">The second vector.</param>
        /// <returns>The cross product of <paramref name="i_vec"/> and <paramref name="i_vec2"/>.</returns>
        public static Vec3<T> Cross(Vec3<T> i_vector, Vec3<T> i_vec2)
        {
            return new()
            {
                p_x = (i_vector.p_y * i_vec2.p_z) - (i_vector.p_z * i_vec2.p_y),
                p_y = (i_vector.p_z * i_vec2.p_x) - (i_vector.p_x * i_vec2.p_z),
                p_z = (i_vector.p_x * i_vec2.p_y) - (i_vector.p_y * i_vec2.p_x)
            };
        }

        #endregion

        #region Reflection methods.

        /// <summary>
        /// Calculates a reflected vector given a normal and incident vector.
        /// </summary>
        /// <param name="i_normal">The normal vector.</param>
        /// <returns>The reflected vector.</returns>
        public static Vec3<T> Reflect(Vec3<T> i_vector, Vec3<T> i_normal)
        {
            return i_vector - (T.CreateChecked(Math<T>.Two) * Dot(i_normal, i_vector) * i_normal);
        }

        #endregion
    }

    public static class Vec3
    {
        extension<T>(Vec3<T>)
            where T : unmanaged, IFloatingPointIeee754<T>
        {
            #region Constructor methods.

            public static Vec3<T> NaN => new(T.NaN);

            /// <summary>
            /// This function takes a rotation matrix and returns a vector representing
            /// the eigenvector and the angle of rotation.
            /// The angle is codified as the vector module.
            /// To get a unit eigenvector, the vector should be normalized.
            /// </summary>
            public static Vec3<T> CreateRotationVectorFromRotationMatrix(Mat3x3<T> i_mat)
            {
                Vec3<T> eigenvector = new();

                eigenvector = Mat3x3<T>.FixedAxisFromRotationMatrix(i_mat);

                Rad<T> theta = Mat3x3<T>.AngleFromRotationMatrix(i_mat);

                eigenvector.p_x *= (T)theta;
                eigenvector.p_y *= (T)theta;
                eigenvector.p_z *= (T)theta;

                return eigenvector;
            }

            /// <summary>
            /// This function takes a quaternion and returns a vector representing
            /// the eigenvector and the angle of rotation.
            /// The angle is codified as the vector module.
            /// To get a unit eigenvector, the vector should be normalized.
            /// </summary>
            /// <param name="i_quat">Input quaternion</param>
            /// <returns>Axis with angle</returns>
            public static Vec3<T> CreateRotationVectorFromQuaternion(Quat<T> i_quat)
            {
                Vec3<T> eigenvector = Vec3<T>.Zero;
                T two = Math<T>.Two;
                Rad<T> theta = Rad<T>.Acos(i_quat.p_w) * two;

                eigenvector.p_x = (T)((i_quat.p_x / Rad<T>.Sin(theta / two)) * theta);
                eigenvector.p_y = (T)((i_quat.p_y / Rad<T>.Sin(theta / two)) * theta);
                eigenvector.p_z = (T)((i_quat.p_z / Rad<T>.Sin(theta / two)) * theta);

                return eigenvector;
            }

            #endregion

            #region Basic Methods

            public static T SquaredMagnitude(Vec3<T> i_vector)
            {
                return (i_vector.p_x * i_vector.p_x) + (i_vector.p_y * i_vector.p_y) + (i_vector.p_z * i_vector.p_z);
            }

            /// <summary>
            /// Returns the Euclidean magnitude of the given vector.
            /// </summary>
            public static T Magnitude(Vec3<T> i_vector)
            {
                return Math<T>.Sqrt((i_vector.p_x * i_vector.p_x) + (i_vector.p_y * i_vector.p_y) + (i_vector.p_z * i_vector.p_z));
            }

            /// <summary>
            /// Returns a copy of the given vector with the new magnitude.
            /// </summary>
            public static Vec3<T> Resize(Vec3<T> i_vector, T i_magnitude)
            {
                return i_vector * (i_magnitude / Magnitude(i_vector));
            }

            /// <summary>
            /// Returns a normalized copy of the given vector.
            /// </summary>
            public static Vec3<T> Normalize(Vec3<T> i_vector)
            {
                T mag = Magnitude(i_vector);
                return i_vector / mag;
            }

            #endregion

            #region Refraction methods.

            /// <summary>
            /// Refracts a vector using Snell's Law.
            /// </summary>
            public static Vec3<T> Refract(Vec3<T> i_vector, Vec3<T> i_normal, T i_refractionIndex1, T i_refractionIndex2)
            {
                // Reference: https://asawicki.info/news_1301_reflect_and_refract_functions.html

                T N_dot_I = Vec3<T>.Dot(i_normal, i_vector);
                T eta = i_refractionIndex1 / i_refractionIndex2;
                T k = T.One - (eta * eta * (T.One - (N_dot_I * N_dot_I)));
                if (k < T.Zero)
                {
                    return Vec3<T>.Zero;
                }
                return (eta * i_vector) - (((eta * N_dot_I) + Math<T>.Sqrt(k)) * i_normal);
            }

            #endregion

            #region Interpolation methods.

            /// <summary>
            /// Linear interpolation.
            /// </summary>
            public static Vec3<T> Lerp(Vec3<T> i_from, Vec3<T> i_to, T i_t)
            {
                return new()
                {
                    p_x = Math<T>.Lerp(i_from.p_x, i_to.p_x, i_t),
                    p_y = Math<T>.Lerp(i_from.p_y, i_to.p_y, i_t),
                    p_z = Math<T>.Lerp(i_from.p_z, i_to.p_z, i_t)
                };
            }

            /// <summary>
            /// Normalized linear interpolation.
            /// </summary>
            public static Vec3<T> Nlerp(Vec3<T> i_from, Vec3<T> i_to, T i_t)
            {
                return Vec3<T>.Normalize(Lerp(i_from, i_to, i_t));
            }

            /// <summary>
            /// Spherical linear interpolation.
            /// </summary>
            public static Vec3<T> Slerp(Vec3<T> i_from, Vec3<T> i_to, T i_t)
            {
                // Reference: https://keithmaggio.wordpress.com/2011/02/15/math-magician-lerp-slerp-and-nlerp/

                // Dot product - the cosine of the angle between 2 vectors.
                T dot = Vec3<T>.Dot(i_from, i_to);
                // Clamp it to be in the range of Acos()
                dot = Math<T>.Clamp(dot, -T.One, T.One);
                // Acos(dot) returns the angle between start and end,
                // And multiplying that by percent returns the angle between
                // start and the final result.
                Rad<T> theta = Rad<T>.Acos(dot) * i_t;
                Vec3<T> relativeVec = i_to - (i_from * dot);
                relativeVec = Normalize(relativeVec);
                // Orthonormal basis
                // The final result.
                return (i_from * Rad<T>.Cos(theta)) + (relativeVec * Rad<T>.Sin(theta));
            }

            #endregion

            #region Distance methods.

            /// <summary>
            /// Returns the squared Euclidean distance between two points.
            /// </summary>
            public static T SquaredDistance(Vec3<T> i_pointA, Vec3<T> i_pointB)
            {
                return ((i_pointB.p_x - i_pointA.p_x) * (i_pointB.p_x - i_pointA.p_x)) +
                    ((i_pointB.p_y - i_pointA.p_y) * (i_pointB.p_y - i_pointA.p_y)) +
                    ((i_pointB.p_z - i_pointA.p_z) * (i_pointB.p_z - i_pointA.p_z));
            }

            /// <summary>
            /// Returns the Euclidean distance between two points.
            /// </summary>
            public static T Distance(Vec3<T> i_pointA, Vec3<T> i_pointB)
            {
                return Math<T>.Sqrt(
                    ((i_pointB.p_x - i_pointA.p_x) * (i_pointB.p_x - i_pointA.p_x)) +
                    ((i_pointB.p_y - i_pointA.p_y) * (i_pointB.p_y - i_pointA.p_y)) +
                    ((i_pointB.p_z - i_pointA.p_z) * (i_pointB.p_z - i_pointA.p_z)));
            }

            /// <summary>
            /// Returns the Euclidean distance between a point and a plane.
            /// </summary>
            public static T Distance(Vec3<T> i_vector, Plane<T> i_plane)
            {
                return Math<T>.Abs(Vec3<T>.Dot(i_plane.p_origin - i_vector, i_plane.p_normal));
            }

            /// <summary>
            /// Returns the Euclidean distance between a point and a segment.
            /// </summary>
            public static T Distance(Vec3<T> i_vector, Segment3D<T> i_segment)
            {
                return Distance(i_vector, Project(i_vector, i_segment));
            }

            /// <summary>
            /// Returns the Euclidean distance between a point and a line.
            /// </summary>
            public static T Distance(Vec3<T> i_vector, Line3D<T> i_line)
            {
                return Distance(i_vector, Project(i_vector, i_line));
            }

            #endregion

            #region Movement methods.

            /// <summary>
            /// Move towards a target.
            /// </summary>
            /// <param name="i_target">The target point.</param>
            /// <param name="i_delta">Positive distance delta. Negative values are clamped to zero.</param>
            /// <param name="o_distance">The distance between the result point and the target.</param>
            /// <returns>The new position or this vector if is equal to the target.</returns>
            public static Vec3<T> MoveTowards(Vec3<T> i_vector, Vec3<T> i_target, T i_delta, out T o_distance)
            {
                if (i_vector == i_target)
                {
                    o_distance = T.Zero;
                    return i_vector;
                }

                i_delta = Math<T>.Max(T.Zero, i_delta);
                Line3D<T> line = Line3D<T>.CreateLineFromPoints(i_vector, i_target);
                Vec3<T> newPos = Line3D<T>.GetPointAlongLine(line, i_delta);
                T dist = Distance(newPos, i_target);

                // Check if the step is greater than the distance to the target
                // or if the current point is already at the target (distance is zero).
                if (dist <= i_delta || dist == T.Zero)
                {
                    o_distance = T.Zero;
                    return i_target;
                }

                o_distance = dist;
                return newPos;
            }

            #endregion

            #region Projection methods.

            /// <summary>
            /// Projects a point on a line.
            /// </summary>
            public static Vec3<T> Project(Vec3<T> i_vector, Line3D<T> i_line)
            {
                //https://forum.unity.com/threads/how-do-i-find-the-closest-point-on-a-line.340058/

                var v = i_vector - i_line.p_origin;
                var d = Vec3<T>.Dot(v, i_line.p_direction);
                return i_line.p_origin + (i_line.p_direction * d);
            }

            /// <summary>
            /// Projects a point on a plane.
            /// </summary>
            public static Vec3<T> Project(Vec3<T> i_vector, Plane<T> i_plane)
            {
                return i_vector + (Distance(i_vector, i_plane) * i_plane.p_normal);
            }

            /// <summary>
            /// Projects a point on a segment.
            /// </summary>
            public static Vec3<T> Project(Vec3<T> i_vector, Segment3D<T> i_segment)
            {
                //https://forum.unity.com/threads/how-do-i-find-the-closest-point-on-a-line.340058/

                Vec3<T> line = i_segment.p_pointB - i_segment.p_pointA;
                T len = Magnitude(line);
                line = Normalize(line);

                Vec3<T> v = i_vector - i_segment.p_pointA;
                T d = Vec3<T>.Dot(v, line);
                d = Math<T>.Clamp(d, T.Zero, len);
                return i_segment.p_pointA + (line * d);
            }

            #endregion
        }
    }
}
