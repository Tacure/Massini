
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.InteropServices;

namespace Massini.Core.Math.Primitives
{
    [StructLayout(LayoutKind.Sequential)]
    public partial struct Vec4<T> : IEquatable<Vec4<T>>
        where T : unmanaged, INumber<T>
    {
        public T p_x;
        public T p_y;
        public T p_z;
        public T p_w;

        public Vec4(T i_value)
        {
            p_x = i_value;
            p_y = i_value;
            p_z = i_value;
            p_w = i_value;
        }

        public Vec4(Vec2<T> i_xy, Vec2<T> i_zw)
        {
            p_x = i_xy.p_x;
            p_y = i_xy.p_y;
            p_z = i_zw.p_x;
            p_w = i_zw.p_y;
        }

        public Vec4(Vec3<T> i_xyz, T i_w)
        {
            p_x = i_xyz.p_x;
            p_y = i_xyz.p_y;
            p_z = i_xyz.p_z;
            p_w = i_w;
        }

        public Vec4(T i_x, T i_y, T i_z, T i_w)
        {
            p_x = i_x;
            p_y = i_y;
            p_z = i_z;
            p_w = i_w;
        }

        /// <inheritdoc/>
        public T this[Index i_index]
        {
            readonly get => i_index.GetOffset(Length) switch
            {
                0 => p_x,
                1 => p_y,
                2 => p_z,
                3 => p_w,
                _ => throw new IndexOutOfRangeException()
            };
            set
            {
                switch (i_index.GetOffset(Length))
                {
                    case 0: p_x = value; break;
                    case 1: p_y = value; break;
                    case 2: p_z = value; break;
                    case 3: p_w = value; break;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }

        public static explicit operator Vector4(Vec4<T> i_other)
            => new(float.CreateTruncating(i_other.p_x), float.CreateTruncating(i_other.p_y), float.CreateTruncating(i_other.p_z), float.CreateTruncating(i_other.p_w));

        public static explicit operator Vec4<T>(Vector4 i_other)
            => new(T.CreateTruncating(i_other.X), T.CreateTruncating(i_other.Y), T.CreateTruncating(i_other.Z), T.CreateTruncating(i_other.W));

        public static Vec4<T> operator -(Vec4<T> value)
        {
            return new(-value.p_x, -value.p_y, -value.p_z, -value.p_w);
        }

        public static Vec4<T> operator +(Vec4<T> i_vector, T i_scalar)
        {
            return new(i_vector.p_x + i_scalar, i_vector.p_y + i_scalar, i_vector.p_z + i_scalar, i_vector.p_w + i_scalar);
        }

        public static Vec4<T> operator +(T i_scalar, Vec4<T> i_vector)
        {
            return new(i_scalar + i_vector.p_x, i_scalar + i_vector.p_y, i_scalar + i_vector.p_z, i_scalar + i_vector.p_w);
        }

        public static Vec4<T> operator +(Vec4<T> left, Vec4<T> right)
        {
            return new(left.p_x + right.p_x, left.p_y + right.p_y, left.p_z + right.p_z, left.p_w + right.p_w);
        }

        public static Vec4<T> operator -(Vec4<T> i_vector, T i_scalar)
        {
            return new(i_vector.p_x - i_scalar, i_vector.p_y - i_scalar, i_vector.p_z - i_scalar, i_vector.p_w - i_scalar);
        }

        public static Vec4<T> operator -(T i_scalar, Vec4<T> i_vector)
        {
            return new(i_scalar - i_vector.p_x, i_scalar - i_vector.p_y, i_scalar - i_vector.p_z, i_scalar - i_vector.p_w);
        }

        public static Vec4<T> operator -(Vec4<T> left, Vec4<T> right)
        {
            return new(left.p_x - right.p_x, left.p_y - right.p_y, left.p_z - right.p_z, left.p_w - right.p_w);
        }

        public static Vec4<T> operator *(Vec4<T> i_vector, T i_scalar)
        {
            return new(i_vector.p_x * i_scalar, i_vector.p_y * i_scalar, i_vector.p_z * i_scalar, i_vector.p_w * i_scalar);
        }

        public static Vec4<T> operator *(T i_scalar, Vec4<T> i_vector)
        {
            return new(i_scalar * i_vector.p_x, i_scalar * i_vector.p_y, i_scalar * i_vector.p_z, i_scalar * i_vector.p_w);
        }

        public static Vec4<T> operator *(Vec4<T> left, Vec4<T> right)
        {
            return new(left.p_x * right.p_x, left.p_y * right.p_y, left.p_z * right.p_z, left.p_w * right.p_w);
        }

        public static Vec4<T> operator /(Vec4<T> i_vector, T i_scalar)
        {
            return new(i_vector.p_x / i_scalar, i_vector.p_y / i_scalar, i_vector.p_z / i_scalar, i_vector.p_w / i_scalar);
        }

        public static Vec4<T> operator /(T i_scalar, Vec4<T> i_vector)
        {
            return new(i_scalar / i_vector.p_x, i_scalar / i_vector.p_y, i_scalar / i_vector.p_z, i_scalar / i_vector.p_w);
        }

        public static Vec4<T> operator /(Vec4<T> left, Vec4<T> right)
        {
            return new(left.p_x / right.p_x, left.p_y / right.p_y, left.p_z / right.p_z, left.p_w / right.p_w);
        }

        public static bool operator ==(Vec4<T> left, Vec4<T> right)
        {
            return left.p_x == right.p_x && left.p_y == right.p_y && left.p_z == right.p_z && left.p_w == right.p_w;
        }

        public static bool operator !=(Vec4<T> left, Vec4<T> right)
        {
            return left.p_x != right.p_x || left.p_y != right.p_y || left.p_z != right.p_z || left.p_w != right.p_w;
        }

        public static Vec4<T> Zero => new(T.Zero);

        public static Vec4<T> One => new(T.One);

        /// <inheritdoc/>
        public static Vec4<T> AdditiveIdentity => Zero;

        public static Vec4<T> UnitX => new(T.One, T.Zero, T.Zero, T.Zero);

        public static Vec4<T> UnitY => new(T.Zero, T.One, T.Zero, T.Zero);

        public static Vec4<T> UnitZ => new(T.Zero, T.Zero, T.One, T.Zero);

        public static Vec4<T> UnitW => new(T.Zero, T.Zero, T.Zero, T.One);

        public readonly int Length => 4;

        public T X { readonly get => p_x; set => p_x = value; }
        public T Y { readonly get => p_y; set => p_y = value; }
        public T Z { readonly get => p_z; set => p_z = value; }
        public T W { readonly get => p_w; set => p_w = value; }

        public readonly bool Equals(Vec4<T> i_other)
        {
            return this == i_other;
        }

        public readonly override bool Equals([NotNullWhen(true)] object? i_obj)
        {
            if (i_obj is Vec4<T> other)
            {
                return this == other;
            }
            return false;
        }

        public readonly override int GetHashCode()
        {
            return HashCode.Combine(p_x, p_y, p_z, p_w);
        }

        public readonly override string ToString()
        {
            return $"[X: {p_x} Y: {p_y} Z: {p_z} W: {p_w}]";
        }
    }

    public partial struct Vec4<T>
    {
        #region Swizzle methods.

        public readonly Vec2<T> XX => new(p_x, p_x);
        public Vec2<T> XY { readonly get => new(p_x, p_y); set { p_x = value.p_x; p_y = value.p_y; } }
        public Vec2<T> XZ { readonly get => new(p_x, p_z); set { p_x = value.p_x; p_z = value.p_y; } }
        public Vec2<T> XW { readonly get => new(p_x, p_w); set { p_x = value.p_x; p_w = value.p_y; } }
        public Vec2<T> YX { readonly get => new(p_y, p_x); set { p_y = value.p_x; p_x = value.p_y; } }
        public readonly Vec2<T> YY => new(p_y, p_y);
        public Vec2<T> YZ { readonly get => new(p_y, p_z); set { p_y = value.p_x; p_z = value.p_y; } }
        public Vec2<T> YW { readonly get => new(p_y, p_w); set { p_y = value.p_x; p_w = value.p_y; } }
        public Vec2<T> ZX { readonly get => new(p_z, p_x); set { p_z = value.p_x; p_x = value.p_y; } }
        public Vec2<T> ZY { readonly get => new(p_z, p_y); set { p_z = value.p_x; p_y = value.p_y; } }
        public readonly Vec2<T> ZZ => new(p_z, p_z);
        public Vec2<T> ZW { readonly get => new(p_z, p_w); set { p_z = value.p_x; p_w = value.p_y; } }
        public Vec2<T> WX { readonly get => new(p_w, p_x); set { p_w = value.p_x; p_x = value.p_y; } }
        public Vec2<T> WY { readonly get => new(p_w, p_y); set { p_w = value.p_x; p_y = value.p_y; } }
        public Vec2<T> WZ { readonly get => new(p_w, p_z); set { p_w = value.p_x; p_z = value.p_y; } }
        public readonly Vec2<T> WW => new(p_w, p_w);

        public readonly Vec3<T> XXX => new(p_x, p_x, p_x);
        public readonly Vec3<T> XXY => new(p_x, p_x, p_y);
        public readonly Vec3<T> XXZ => new(p_x, p_x, p_z);
        public readonly Vec3<T> XXW => new(p_x, p_x, p_w);
        public readonly Vec3<T> XYX => new(p_x, p_y, p_x);
        public readonly Vec3<T> XYY => new(p_x, p_y, p_y);
        public Vec3<T> XYZ { readonly get => new(p_x, p_y, p_z); set { p_x = value.p_x; p_y = value.p_y; p_z = value.p_z; } }
        public Vec3<T> XYW { readonly get => new(p_x, p_y, p_w); set { p_x = value.p_x; p_y = value.p_y; p_w = value.p_z; } }
        public readonly Vec3<T> XZX => new(p_x, p_z, p_x);
        public Vec3<T> XZY { readonly get => new(p_x, p_z, p_y); set { p_x = value.p_x; p_z = value.p_y; p_y = value.p_z; } }
        public readonly Vec3<T> XZZ => new(p_x, p_z, p_z);
        public Vec3<T> XZW { readonly get => new(p_x, p_z, p_w); set { p_x = value.p_x; p_z = value.p_y; p_w = value.p_z; } }
        public readonly Vec3<T> XWX => new(p_x, p_w, p_x);
        public Vec3<T> XWY { readonly get => new(p_x, p_w, p_y); set { p_x = value.p_x; p_w = value.p_y; p_y = value.p_z; } }
        public Vec3<T> XWZ { readonly get => new(p_x, p_w, p_z); set { p_x = value.p_x; p_w = value.p_y; p_z = value.p_z; } }
        public readonly Vec3<T> XWW => new(p_x, p_w, p_w);
        public readonly Vec3<T> YXX => new(p_y, p_x, p_x);
        public readonly Vec3<T> YXY => new(p_y, p_x, p_y);
        public Vec3<T> YXZ { readonly get => new(p_y, p_x, p_z); set { p_y = value.p_x; p_x = value.p_y; p_z = value.p_z; } }
        public Vec3<T> YXW { readonly get => new(p_y, p_x, p_w); set { p_y = value.p_x; p_x = value.p_y; p_w = value.p_z; } }
        public readonly Vec3<T> YYX => new(p_y, p_y, p_x);
        public readonly Vec3<T> YYY => new(p_y, p_y, p_y);
        public readonly Vec3<T> YYZ => new(p_y, p_y, p_z);
        public readonly Vec3<T> YYW => new(p_y, p_y, p_w);
        public Vec3<T> YZX { readonly get => new(p_y, p_z, p_x); set { p_y = value.p_x; p_z = value.p_y; p_x = value.p_z; } }
        public readonly Vec3<T> YZY => new(p_y, p_z, p_y);
        public readonly Vec3<T> YZZ => new(p_y, p_z, p_z);
        public Vec3<T> YZW { readonly get => new(p_y, p_z, p_w); set { p_y = value.p_x; p_z = value.p_y; p_w = value.p_z; } }
        public Vec3<T> YWX { readonly get => new(p_y, p_w, p_x); set { p_y = value.p_x; p_w = value.p_y; p_x = value.p_z; } }
        public readonly Vec3<T> YWY => new(p_y, p_w, p_y);
        public Vec3<T> YWZ { readonly get => new(p_y, p_w, p_z); set { p_y = value.p_x; p_w = value.p_y; p_z = value.p_z; } }
        public readonly Vec3<T> YWW => new(p_y, p_w, p_w);
        public readonly Vec3<T> ZXX => new(p_z, p_x, p_x);
        public Vec3<T> ZXY { readonly get => new(p_z, p_x, p_y); set { p_z = value.p_x; p_x = value.p_y; p_y = value.p_z; } }
        public readonly Vec3<T> ZXZ => new(p_z, p_x, p_z);
        public Vec3<T> ZXW { readonly get => new(p_z, p_x, p_w); set { p_z = value.p_x; p_x = value.p_y; p_w = value.p_z; } }
        public Vec3<T> ZYX { readonly get => new(p_z, p_y, p_x); set { p_z = value.p_x; p_y = value.p_y; p_x = value.p_z; } }
        public readonly Vec3<T> ZYY => new(p_z, p_y, p_y);
        public readonly Vec3<T> ZYZ => new(p_z, p_y, p_z);
        public Vec3<T> ZYW { readonly get => new(p_z, p_y, p_w); set { p_z = value.p_x; p_y = value.p_y; p_w = value.p_z; } }
        public readonly Vec3<T> ZZX => new(p_z, p_z, p_x);
        public readonly Vec3<T> ZZY => new(p_z, p_z, p_y);
        public readonly Vec3<T> ZZZ => new(p_z, p_z, p_z);
        public readonly Vec3<T> ZZW => new(p_z, p_z, p_w);
        public Vec3<T> ZWX { readonly get => new(p_z, p_w, p_x); set { p_z = value.p_x; p_w = value.p_y; p_x = value.p_z; } }
        public Vec3<T> ZWY { readonly get => new(p_z, p_w, p_y); set { p_z = value.p_x; p_w = value.p_y; p_y = value.p_z; } }
        public readonly Vec3<T> ZWZ => new(p_z, p_w, p_z);
        public readonly Vec3<T> ZWW => new(p_z, p_w, p_w);
        public readonly Vec3<T> WXX => new(p_w, p_x, p_x);
        public Vec3<T> WXY { readonly get => new(p_w, p_x, p_y); set { p_w = value.p_x; p_x = value.p_y; p_y = value.p_z; } }
        public Vec3<T> WXZ { readonly get => new(p_w, p_x, p_z); set { p_w = value.p_x; p_x = value.p_y; p_z = value.p_z; } }
        public readonly Vec3<T> WXW => new(p_w, p_x, p_w);
        public Vec3<T> WYX { readonly get => new(p_w, p_y, p_x); set { p_w = value.p_x; p_y = value.p_y; p_x = value.p_z; } }
        public readonly Vec3<T> WYY => new(p_w, p_y, p_y);
        public Vec3<T> WYZ { readonly get => new(p_w, p_y, p_z); set { p_w = value.p_x; p_y = value.p_y; p_z = value.p_z; } }
        public readonly Vec3<T> WYW => new(p_w, p_y, p_w);
        public Vec3<T> WZX { readonly get => new(p_w, p_z, p_x); set { p_w = value.p_x; p_z = value.p_y; p_x = value.p_z; } }
        public Vec3<T> WZY { readonly get => new(p_w, p_z, p_y); set { p_w = value.p_x; p_z = value.p_y; p_y = value.p_z; } }
        public readonly Vec3<T> WZZ => new(p_w, p_z, p_z);
        public readonly Vec3<T> WZW => new(p_w, p_z, p_w);
        public readonly Vec3<T> WWX => new(p_w, p_w, p_x);
        public readonly Vec3<T> WWY => new(p_w, p_w, p_y);
        public readonly Vec3<T> WWZ => new(p_w, p_w, p_z);
        public readonly Vec3<T> WWW => new(p_w, p_w, p_w);

        public readonly Vec4<T> XXXX => new(p_x, p_x, p_x, p_x);
        public readonly Vec4<T> XXXY => new(p_x, p_x, p_x, p_y);
        public readonly Vec4<T> XXXZ => new(p_x, p_x, p_x, p_z);
        public readonly Vec4<T> XXXW => new(p_x, p_x, p_x, p_w);
        public readonly Vec4<T> XXYX => new(p_x, p_x, p_y, p_x);
        public readonly Vec4<T> XXYY => new(p_x, p_x, p_y, p_y);
        public readonly Vec4<T> XXYZ => new(p_x, p_x, p_y, p_z);
        public readonly Vec4<T> XXYW => new(p_x, p_x, p_y, p_w);
        public readonly Vec4<T> XXZX => new(p_x, p_x, p_z, p_x);
        public readonly Vec4<T> XXZY => new(p_x, p_x, p_z, p_y);
        public readonly Vec4<T> XXZZ => new(p_x, p_x, p_z, p_z);
        public readonly Vec4<T> XXZW => new(p_x, p_x, p_z, p_w);
        public readonly Vec4<T> XXWX => new(p_x, p_x, p_w, p_x);
        public readonly Vec4<T> XXWY => new(p_x, p_x, p_w, p_y);
        public readonly Vec4<T> XXWZ => new(p_x, p_x, p_w, p_z);
        public readonly Vec4<T> XXWW => new(p_x, p_x, p_w, p_w);
        public readonly Vec4<T> XYXX => new(p_x, p_y, p_x, p_x);
        public readonly Vec4<T> XYXY => new(p_x, p_y, p_x, p_y);
        public readonly Vec4<T> XYXZ => new(p_x, p_y, p_x, p_z);
        public readonly Vec4<T> XYXW => new(p_x, p_y, p_x, p_w);
        public readonly Vec4<T> XYYX => new(p_x, p_y, p_y, p_x);
        public readonly Vec4<T> XYYY => new(p_x, p_y, p_y, p_y);
        public readonly Vec4<T> XYYZ => new(p_x, p_y, p_y, p_z);
        public readonly Vec4<T> XYYW => new(p_x, p_y, p_y, p_w);
        public readonly Vec4<T> XYZX => new(p_x, p_y, p_z, p_x);
        public readonly Vec4<T> XYZY => new(p_x, p_y, p_z, p_y);
        public readonly Vec4<T> XYZZ => new(p_x, p_y, p_z, p_z);
        public Vec4<T> XYZW { get => new(p_x, p_y, p_z, p_w); set { p_x = value.p_x; p_y = value.p_y; p_z = value.p_z; p_w = value.p_w; } }
        public readonly Vec4<T> XYWX => new(p_x, p_y, p_w, p_x);
        public readonly Vec4<T> XYWY => new(p_x, p_y, p_w, p_y);
        public Vec4<T> XYWZ { get => new(p_x, p_y, p_w, p_z); set { p_x = value.p_x; p_y = value.p_y; p_w = value.p_z; p_z = value.p_w; } }
        public readonly Vec4<T> XYWW => new(p_x, p_y, p_w, p_w);
        public readonly Vec4<T> XZXX => new(p_x, p_z, p_x, p_x);
        public readonly Vec4<T> XZXY => new(p_x, p_z, p_x, p_y);
        public readonly Vec4<T> XZXZ => new(p_x, p_z, p_x, p_z);
        public readonly Vec4<T> XZXW => new(p_x, p_z, p_x, p_w);
        public readonly Vec4<T> XZYX => new(p_x, p_z, p_y, p_x);
        public readonly Vec4<T> XZYY => new(p_x, p_z, p_y, p_y);
        public Vec4<T> XZYW { get => new(p_x, p_z, p_y, p_w); set { p_x = value.p_x; p_z = value.p_y; p_y = value.p_z; p_w = value.p_w; } }
        public readonly Vec4<T> XZYZ => new(p_x, p_z, p_y, p_z);
        public readonly Vec4<T> XZZX => new(p_x, p_z, p_z, p_x);
        public readonly Vec4<T> XZZY => new(p_x, p_z, p_z, p_y);
        public readonly Vec4<T> XZZZ => new(p_x, p_z, p_z, p_z);
        public readonly Vec4<T> XZZW => new(p_x, p_z, p_z, p_w);
        public readonly Vec4<T> XZWX => new(p_x, p_z, p_w, p_x);
        public Vec4<T> XZWY { get => new(p_x, p_z, p_w, p_y); set { p_x = value.p_x; p_z = value.p_y; p_w = value.p_z; p_y = value.p_w; } }
        public readonly Vec4<T> XZWZ => new(p_x, p_z, p_w, p_z);
        public readonly Vec4<T> XZWW => new(p_x, p_z, p_w, p_w);
        public readonly Vec4<T> XWXX => new(p_x, p_w, p_x, p_x);
        public readonly Vec4<T> XWXY => new(p_x, p_w, p_x, p_y);
        public readonly Vec4<T> XWXZ => new(p_x, p_w, p_x, p_z);
        public readonly Vec4<T> XWXW => new(p_x, p_w, p_x, p_w);
        public readonly Vec4<T> XWYX => new(p_x, p_w, p_y, p_x);
        public readonly Vec4<T> XWYY => new(p_x, p_w, p_y, p_y);
        public Vec4<T> XWYZ { get => new(p_x, p_w, p_y, p_z); set { p_x = value.p_x; p_w = value.p_y; p_y = value.p_z; p_z = value.p_w; } }
        public readonly Vec4<T> XWYW => new(p_x, p_w, p_y, p_w);
        public readonly Vec4<T> XWZX => new(p_x, p_w, p_z, p_x);
        public Vec4<T> XWZY { get => new(p_x, p_w, p_z, p_y); set { p_x = value.p_x; p_w = value.p_y; p_z = value.p_z; p_y = value.p_w; } }
        public readonly Vec4<T> XWZZ => new(p_x, p_w, p_z, p_z);
        public readonly Vec4<T> XWZW => new(p_x, p_w, p_z, p_w);
        public readonly Vec4<T> XWWX => new(p_x, p_w, p_w, p_x);
        public readonly Vec4<T> XWWY => new(p_x, p_w, p_w, p_y);
        public readonly Vec4<T> XWWZ => new(p_x, p_w, p_w, p_z);
        public readonly Vec4<T> XWWW => new(p_x, p_w, p_w, p_w);
        public readonly Vec4<T> YXXX => new(p_y, p_x, p_x, p_x);
        public readonly Vec4<T> YXXY => new(p_y, p_x, p_x, p_y);
        public readonly Vec4<T> YXXZ => new(p_y, p_x, p_x, p_z);
        public readonly Vec4<T> YXXW => new(p_y, p_x, p_x, p_w);
        public readonly Vec4<T> YXYX => new(p_y, p_x, p_y, p_x);
        public readonly Vec4<T> YXYY => new(p_y, p_x, p_y, p_y);
        public readonly Vec4<T> YXYZ => new(p_y, p_x, p_y, p_z);
        public readonly Vec4<T> YXYW => new(p_y, p_x, p_y, p_w);
        public readonly Vec4<T> YXZX => new(p_y, p_x, p_z, p_x);
        public readonly Vec4<T> YXZY => new(p_y, p_x, p_z, p_y);
        public readonly Vec4<T> YXZZ => new(p_y, p_x, p_z, p_z);
        public Vec4<T> YXZW { get => new(p_y, p_x, p_z, p_w); set { p_y = value.p_x; p_x = value.p_y; p_z = value.p_z; p_w = value.p_w; } }
        public readonly Vec4<T> YXWX => new(p_y, p_x, p_w, p_x);
        public readonly Vec4<T> YXWY => new(p_y, p_x, p_w, p_y);
        public Vec4<T> YXWZ { get => new(p_y, p_x, p_w, p_z); set { p_y = value.p_x; p_x = value.p_y; p_w = value.p_z; p_z = value.p_w; } }
        public readonly Vec4<T> YXWW => new(p_y, p_x, p_w, p_w);
        public readonly Vec4<T> YYXX => new(p_y, p_y, p_x, p_x);
        public readonly Vec4<T> YYXY => new(p_y, p_y, p_x, p_y);
        public readonly Vec4<T> YYXZ => new(p_y, p_y, p_x, p_z);
        public readonly Vec4<T> YYXW => new(p_y, p_y, p_x, p_w);
        public readonly Vec4<T> YYYX => new(p_y, p_y, p_y, p_x);
        public readonly Vec4<T> YYYY => new(p_y, p_y, p_y, p_y);
        public readonly Vec4<T> YYYZ => new(p_y, p_y, p_y, p_z);
        public readonly Vec4<T> YYYW => new(p_y, p_y, p_y, p_w);
        public readonly Vec4<T> YYZX => new(p_y, p_y, p_z, p_x);
        public readonly Vec4<T> YYZY => new(p_y, p_y, p_z, p_y);
        public readonly Vec4<T> YYZZ => new(p_y, p_y, p_z, p_z);
        public readonly Vec4<T> YYZW => new(p_y, p_y, p_z, p_w);
        public readonly Vec4<T> YYWX => new(p_y, p_y, p_w, p_x);
        public readonly Vec4<T> YYWY => new(p_y, p_y, p_w, p_y);
        public readonly Vec4<T> YYWZ => new(p_y, p_y, p_w, p_z);
        public readonly Vec4<T> YYWW => new(p_y, p_y, p_w, p_w);
        public readonly Vec4<T> YZXX => new(p_y, p_z, p_x, p_x);
        public readonly Vec4<T> YZXY => new(p_y, p_z, p_x, p_y);
        public readonly Vec4<T> YZXZ => new(p_y, p_z, p_x, p_z);
        public Vec4<T> YZXW { get => new(p_y, p_z, p_x, p_w); set { p_y = value.p_x; p_z = value.p_y; p_x = value.p_z; p_w = value.p_w; } }
        public readonly Vec4<T> YZYX => new(p_y, p_z, p_y, p_x);
        public readonly Vec4<T> YZYY => new(p_y, p_z, p_y, p_y);
        public readonly Vec4<T> YZYZ => new(p_y, p_z, p_y, p_z);
        public readonly Vec4<T> YZYW => new(p_y, p_z, p_y, p_w);
        public readonly Vec4<T> YZZX => new(p_y, p_z, p_z, p_x);
        public readonly Vec4<T> YZZY => new(p_y, p_z, p_z, p_y);
        public readonly Vec4<T> YZZZ => new(p_y, p_z, p_z, p_z);
        public readonly Vec4<T> YZZW => new(p_y, p_z, p_z, p_w);
        public Vec4<T> YZWX { get => new(p_y, p_z, p_w, p_x); set { p_y = value.p_x; p_z = value.p_y; p_w = value.p_z; p_x = value.p_w; } }
        public readonly Vec4<T> YZWY => new(p_y, p_z, p_w, p_y);
        public readonly Vec4<T> YZWZ => new(p_y, p_z, p_w, p_z);
        public readonly Vec4<T> YZWW => new(p_y, p_z, p_w, p_w);
        public readonly Vec4<T> YWXX => new(p_y, p_w, p_x, p_x);
        public readonly Vec4<T> YWXY => new(p_y, p_w, p_x, p_y);
        public Vec4<T> YWXZ { get => new(p_y, p_w, p_x, p_z); set { p_y = value.p_x; p_w = value.p_y; p_x = value.p_z; p_z = value.p_w; } }
        public readonly Vec4<T> YWXW => new(p_y, p_w, p_x, p_w);
        public readonly Vec4<T> YWYX => new(p_y, p_w, p_y, p_x);
        public readonly Vec4<T> YWYY => new(p_y, p_w, p_y, p_y);
        public readonly Vec4<T> YWYZ => new(p_y, p_w, p_y, p_z);
        public readonly Vec4<T> YWYW => new(p_y, p_w, p_y, p_w);
        public Vec4<T> YWZX { get => new(p_y, p_w, p_z, p_x); set { p_y = value.p_x; p_w = value.p_y; p_z = value.p_z; p_x = value.p_w; } }
        public readonly Vec4<T> YWZY => new(p_y, p_w, p_z, p_y);
        public readonly Vec4<T> YWZZ => new(p_y, p_w, p_z, p_z);
        public readonly Vec4<T> YWZW => new(p_y, p_w, p_z, p_w);
        public readonly Vec4<T> YWWX => new(p_y, p_w, p_w, p_x);
        public readonly Vec4<T> YWWY => new(p_y, p_w, p_w, p_y);
        public readonly Vec4<T> YWWZ => new(p_y, p_w, p_w, p_z);
        public readonly Vec4<T> YWWW => new(p_y, p_w, p_w, p_w);
        public readonly Vec4<T> ZXXX => new(p_z, p_x, p_x, p_x);
        public readonly Vec4<T> ZXXY => new(p_z, p_x, p_x, p_y);
        public readonly Vec4<T> ZXXZ => new(p_z, p_x, p_x, p_z);
        public readonly Vec4<T> ZXXW => new(p_z, p_x, p_x, p_w);
        public readonly Vec4<T> ZXYX => new(p_z, p_x, p_y, p_x);
        public readonly Vec4<T> ZXYY => new(p_z, p_x, p_y, p_y);
        public readonly Vec4<T> ZXYZ => new(p_z, p_x, p_y, p_z);
        public Vec4<T> ZXYW { get => new(p_z, p_x, p_y, p_w); set { p_z = value.p_x; p_x = value.p_y; p_y = value.p_z; p_w = value.p_w; } }
        public readonly Vec4<T> ZXZX => new(p_z, p_x, p_z, p_x);
        public readonly Vec4<T> ZXZY => new(p_z, p_x, p_z, p_y);
        public readonly Vec4<T> ZXZZ => new(p_z, p_x, p_z, p_z);
        public readonly Vec4<T> ZXZW => new(p_z, p_x, p_z, p_w);
        public readonly Vec4<T> ZXWX => new(p_z, p_x, p_w, p_x);
        public Vec4<T> ZXWY { get => new(p_z, p_x, p_w, p_y); set { p_z = value.p_x; p_x = value.p_y; p_w = value.p_z; p_y = value.p_w; } }
        public readonly Vec4<T> ZXWZ => new(p_z, p_x, p_w, p_z);
        public readonly Vec4<T> ZXWW => new(p_z, p_x, p_w, p_w);
        public readonly Vec4<T> ZYXX => new(p_z, p_y, p_x, p_x);
        public readonly Vec4<T> ZYXY => new(p_z, p_y, p_x, p_y);
        public readonly Vec4<T> ZYXZ => new(p_z, p_y, p_x, p_z);
        public Vec4<T> ZYXW { get => new(p_z, p_y, p_x, p_w); set { p_z = value.p_x; p_y = value.p_y; p_x = value.p_z; p_w = value.p_w; } }
        public readonly Vec4<T> ZYYX => new(p_z, p_y, p_y, p_x);
        public readonly Vec4<T> ZYYY => new(p_z, p_y, p_y, p_y);
        public readonly Vec4<T> ZYYZ => new(p_z, p_y, p_y, p_z);
        public readonly Vec4<T> ZYYW => new(p_z, p_y, p_y, p_w);
        public readonly Vec4<T> ZYZX => new(p_z, p_y, p_z, p_x);
        public readonly Vec4<T> ZYZY => new(p_z, p_y, p_z, p_y);
        public readonly Vec4<T> ZYZZ => new(p_z, p_y, p_z, p_z);
        public readonly Vec4<T> ZYZW => new(p_z, p_y, p_z, p_w);
        public Vec4<T> ZYWX { get => new(p_z, p_y, p_w, p_x); set { p_z = value.p_x; p_y = value.p_y; p_w = value.p_z; p_x = value.p_w; } }
        public readonly Vec4<T> ZYWY => new(p_z, p_y, p_w, p_y);
        public readonly Vec4<T> ZYWZ => new(p_z, p_y, p_w, p_z);
        public readonly Vec4<T> ZYWW => new(p_z, p_y, p_w, p_w);
        public readonly Vec4<T> ZZXX => new(p_z, p_z, p_x, p_x);
        public readonly Vec4<T> ZZXY => new(p_z, p_z, p_x, p_y);
        public readonly Vec4<T> ZZXZ => new(p_z, p_z, p_x, p_z);
        public readonly Vec4<T> ZZXW => new(p_z, p_z, p_x, p_w);
        public readonly Vec4<T> ZZYX => new(p_z, p_z, p_y, p_x);
        public readonly Vec4<T> ZZYY => new(p_z, p_z, p_y, p_y);
        public readonly Vec4<T> ZZYZ => new(p_z, p_z, p_y, p_z);
        public readonly Vec4<T> ZZYW => new(p_z, p_z, p_y, p_w);
        public readonly Vec4<T> ZZZX => new(p_z, p_z, p_z, p_x);
        public readonly Vec4<T> ZZZY => new(p_z, p_z, p_z, p_y);
        public readonly Vec4<T> ZZZZ => new(p_z, p_z, p_z, p_z);
        public readonly Vec4<T> ZZZW => new(p_z, p_z, p_z, p_w);
        public readonly Vec4<T> ZZWX => new(p_z, p_z, p_w, p_x);
        public readonly Vec4<T> ZZWY => new(p_z, p_z, p_w, p_y);
        public readonly Vec4<T> ZZWZ => new(p_z, p_z, p_w, p_z);
        public readonly Vec4<T> ZZWW => new(p_z, p_z, p_w, p_w);
        public readonly Vec4<T> ZWXX => new(p_z, p_w, p_x, p_x);
        public Vec4<T> ZWXY { get => new(p_z, p_w, p_x, p_y); set { p_z = value.p_x; p_w = value.p_y; p_x = value.p_z; p_y = value.p_w; } }
        public readonly Vec4<T> ZWXZ => new(p_z, p_w, p_x, p_z);
        public readonly Vec4<T> ZWXW => new(p_z, p_w, p_x, p_w);
        public Vec4<T> ZWYX { get => new(p_z, p_w, p_y, p_x); set { p_z = value.p_x; p_w = value.p_y; p_y = value.p_z; p_x = value.p_w; } }
        public readonly Vec4<T> ZWYY => new(p_z, p_w, p_y, p_y);
        public readonly Vec4<T> ZWYZ => new(p_z, p_w, p_y, p_z);
        public readonly Vec4<T> ZWYW => new(p_z, p_w, p_y, p_w);
        public readonly Vec4<T> ZWZX => new(p_z, p_w, p_z, p_x);
        public readonly Vec4<T> ZWZY => new(p_z, p_w, p_z, p_y);
        public readonly Vec4<T> ZWZZ => new(p_z, p_w, p_z, p_z);
        public readonly Vec4<T> ZWZW => new(p_z, p_w, p_z, p_w);
        public readonly Vec4<T> ZWWX => new(p_z, p_w, p_w, p_x);
        public readonly Vec4<T> ZWWY => new(p_z, p_w, p_w, p_y);
        public readonly Vec4<T> ZWWZ => new(p_z, p_w, p_w, p_z);
        public readonly Vec4<T> ZWWW => new(p_z, p_w, p_w, p_w);
        public readonly Vec4<T> WXXX => new(p_w, p_x, p_x, p_x);
        public readonly Vec4<T> WXXY => new(p_w, p_x, p_x, p_y);
        public readonly Vec4<T> WXXZ => new(p_w, p_x, p_x, p_z);
        public readonly Vec4<T> WXXW => new(p_w, p_x, p_x, p_w);
        public readonly Vec4<T> WXYX => new(p_w, p_x, p_y, p_x);
        public readonly Vec4<T> WXYY => new(p_w, p_x, p_y, p_y);
        public Vec4<T> WXYZ { get => new(p_w, p_x, p_y, p_z); set { p_w = value.p_x; p_x = value.p_y; p_y = value.p_z; p_z = value.p_w; } }
        public readonly Vec4<T> WXYW => new(p_w, p_x, p_y, p_w);
        public readonly Vec4<T> WXZX => new(p_w, p_x, p_z, p_x);
        public Vec4<T> WXZY { get => new(p_w, p_x, p_z, p_y); set { p_w = value.p_x; p_x = value.p_y; p_z = value.p_z; p_y = value.p_w; } }
        public readonly Vec4<T> WXZZ => new(p_w, p_x, p_z, p_z);
        public readonly Vec4<T> WXZW => new(p_w, p_x, p_z, p_w);
        public readonly Vec4<T> WXWX => new(p_w, p_x, p_w, p_x);
        public readonly Vec4<T> WXWY => new(p_w, p_x, p_w, p_y);
        public readonly Vec4<T> WXWZ => new(p_w, p_x, p_w, p_z);
        public readonly Vec4<T> WXWW => new(p_w, p_x, p_w, p_w);
        public readonly Vec4<T> WYXX => new(p_w, p_y, p_x, p_x);
        public readonly Vec4<T> WYXY => new(p_w, p_y, p_x, p_y);
        public Vec4<T> WYXZ { get => new(p_w, p_y, p_x, p_z); set { p_w = value.p_x; p_y = value.p_y; p_x = value.p_z; p_z = value.p_w; } }
        public readonly Vec4<T> WYXW => new(p_w, p_y, p_x, p_w);
        public readonly Vec4<T> WYYX => new(p_w, p_y, p_y, p_x);
        public readonly Vec4<T> WYYY => new(p_w, p_y, p_y, p_y);
        public readonly Vec4<T> WYYZ => new(p_w, p_y, p_y, p_z);
        public readonly Vec4<T> WYYW => new(p_w, p_y, p_y, p_w);
        public Vec4<T> WYZX { get => new(p_w, p_y, p_z, p_x); set { p_w = value.p_x; p_y = value.p_y; p_z = value.p_z; p_x = value.p_w; } }
        public readonly Vec4<T> WYZY => new(p_w, p_y, p_z, p_y);
        public readonly Vec4<T> WYZZ => new(p_w, p_y, p_z, p_z);
        public readonly Vec4<T> WYZW => new(p_w, p_y, p_z, p_w);
        public readonly Vec4<T> WYWX => new(p_w, p_y, p_w, p_x);
        public readonly Vec4<T> WYWY => new(p_w, p_y, p_w, p_y);
        public readonly Vec4<T> WYWZ => new(p_w, p_y, p_w, p_z);
        public readonly Vec4<T> WYWW => new(p_w, p_y, p_w, p_w);
        public readonly Vec4<T> WZXX => new(p_w, p_z, p_x, p_x);
        public Vec4<T> WZXY { get => new(p_w, p_z, p_x, p_y); set { p_w = value.p_x; p_z = value.p_y; p_x = value.p_z; p_y = value.p_w; } }
        public readonly Vec4<T> WZXZ => new(p_w, p_z, p_x, p_z);
        public readonly Vec4<T> WZXW => new(p_w, p_z, p_x, p_w);
        public Vec4<T> WZYX { get => new(p_w, p_z, p_y, p_x); set { p_w = value.p_x; p_z = value.p_y; p_y = value.p_z; p_x = value.p_w; } }
        public readonly Vec4<T> WZYY => new(p_w, p_z, p_y, p_y);
        public readonly Vec4<T> WZYZ => new(p_w, p_z, p_y, p_z);
        public readonly Vec4<T> WZYW => new(p_w, p_z, p_y, p_w);
        public readonly Vec4<T> WZZX => new(p_w, p_z, p_z, p_x);
        public readonly Vec4<T> WZZY => new(p_w, p_z, p_z, p_y);
        public readonly Vec4<T> WZZZ => new(p_w, p_z, p_z, p_z);
        public readonly Vec4<T> WZZW => new(p_w, p_z, p_z, p_w);
        public readonly Vec4<T> WZWX => new(p_w, p_z, p_w, p_x);
        public readonly Vec4<T> WZWY => new(p_w, p_z, p_w, p_y);
        public readonly Vec4<T> WZWZ => new(p_w, p_z, p_w, p_z);
        public readonly Vec4<T> WZWW => new(p_w, p_z, p_w, p_w);
        public readonly Vec4<T> WWXX => new(p_w, p_w, p_x, p_x);
        public readonly Vec4<T> WWXY => new(p_w, p_w, p_x, p_y);
        public readonly Vec4<T> WWXZ => new(p_w, p_w, p_x, p_z);
        public readonly Vec4<T> WWXW => new(p_w, p_w, p_x, p_w);
        public readonly Vec4<T> WWYX => new(p_w, p_w, p_y, p_x);
        public readonly Vec4<T> WWYY => new(p_w, p_w, p_y, p_y);
        public readonly Vec4<T> WWYZ => new(p_w, p_w, p_y, p_z);
        public readonly Vec4<T> WWYW => new(p_w, p_w, p_y, p_w);
        public readonly Vec4<T> WWZX => new(p_w, p_w, p_z, p_x);
        public readonly Vec4<T> WWZY => new(p_w, p_w, p_z, p_y);
        public readonly Vec4<T> WWZZ => new(p_w, p_w, p_z, p_z);
        public readonly Vec4<T> WWZW => new(p_w, p_w, p_z, p_w);
        public readonly Vec4<T> WWWX => new(p_w, p_w, p_w, p_x);
        public readonly Vec4<T> WWWY => new(p_w, p_w, p_w, p_y);
        public readonly Vec4<T> WWWZ => new(p_w, p_w, p_w, p_z);
        public readonly Vec4<T> WWWW => new(p_w, p_w, p_w, p_w);

        #endregion
    }
}
