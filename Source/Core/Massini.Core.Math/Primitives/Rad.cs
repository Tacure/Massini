
using System.Numerics;

namespace Massini.Math.Primitives
{
    public readonly partial struct Rad<T>(T i_value)
        where T : unmanaged, IFloatingPointIeee754<T>
    {
        public static explicit operator T(Rad<T> i_value) => i_value.m_value;

        public static explicit operator Rad<T>(T i_value) => new(i_value);

        public static bool operator >(Rad<T> left, Rad<T> right)
        {
            return left.m_value > right.m_value;
        }

        public static bool operator >=(Rad<T> left, Rad<T> right)
        {
            return left.m_value >= right.m_value;
        }

        public static bool operator <(Rad<T> left, Rad<T> right)
        {
            return left.m_value < right.m_value;
        }

        public static bool operator <=(Rad<T> left, Rad<T> right)
        {
            return left.m_value <= right.m_value;
        }

        public static Rad<T> operator %(Rad<T> left, Rad<T> right)
        {
            return new(left.m_value % right.m_value);
        }

        public static Rad<T> operator +(Rad<T> left, Rad<T> right)
        {
            return new(left.m_value + right.m_value);
        }

        public static Rad<T> operator --(Rad<T> value)
        {
            return new(value.m_value - T.One);
        }

        public static Rad<T> operator /(Rad<T> left, Rad<T> right)
        {
            return new(left.m_value / right.m_value);
        }

        public static bool operator ==(Rad<T> left, Rad<T> right)
        {
            return left.m_value == right.m_value;
        }

        public static bool operator !=(Rad<T> left, Rad<T> right)
        {
            return left.m_value != right.m_value;
        }

        public static Rad<T> operator ++(Rad<T> value)
        {
            return new(value.m_value + T.One);
        }

        public static Rad<T> operator *(Rad<T> left, Rad<T> right)
        {
            return new(left.m_value * right.m_value);
        }

        public static Rad<T> operator *(Rad<T> i_radians, T i_scalar)
        {
            return new(i_radians.m_value * i_scalar);
        }

        public static Rad<T> operator *(T i_scalar, Rad<T> i_radians)
        {
            return new(i_radians.m_value * i_scalar);
        }

        public static Rad<T> operator /(Rad<T> i_radians, T i_scalar)
        {
            return new(i_radians.m_value / i_scalar);
        }

        public static Vec3<T> operator *(Rad<T> i_radians, Vec3<T> i_vector)
        {
            return i_radians.m_value * i_vector;
        }

        public static Vec3<T> operator *(Vec3<T> i_vector, Rad<T> i_radians)
        {
            return i_vector * i_radians.m_value;
        }

        public static Rad<T> operator -(Rad<T> left, Rad<T> right)
        {
            return new(left.m_value - right.m_value);
        }

        public static Rad<T> operator -(Rad<T> value)
        {
            return new(-value.m_value);
        }

        public static Rad<T> operator +(Rad<T> value)
        {
            return value;
        }

        public static Rad<T> Zero => new(T.Zero);

        public static Rad<T> Pi => new(T.Pi);

        public static Rad<T> Tau => new(T.Tau);

        public override bool Equals(object? i_obj)
        {
            return i_obj is Rad<T> other && this == other;
        }

        public override int GetHashCode()
        {
            return m_value.GetHashCode();
        }

        public override string ToString()
        {
            return $"{m_value} rad";
        }

        private readonly T m_value = i_value;
    }

    public static class Rad
    {
        extension<T>(Rad<T>)
            where T : unmanaged, IFloatingPointIeee754<T>
        {
            #region  Basic methods.

            /// <summary>
            /// Converts degrees to radians.
            /// </summary>
            public static Rad<T> DegreesToRadians(Deg<T> i_radians)
            {
                return (Rad<T>)T.DegreesToRadians((T)i_radians);
            }

            /// <summary>
            /// Computes the inverse of the sine.
            /// </summary>
            public static Rad<T> Asin(T i_val)
            {
                return (Rad<T>)T.Asin(i_val);
            }

            /// <summary>
            /// Computes the inverse of the cosine.
            /// </summary>
            public static Rad<T> Acos(T i_val)
            {
                return (Rad<T>)T.Acos(i_val);
            }

            /// <summary>
            /// Computes the inverse of the tangent.
            /// </summary>
            public static Rad<T> Atan(T i_val)
            {
                return (Rad<T>)T.Atan(i_val);
            }

            /// <summary>
            /// Computes the angle in radians of the given direction vector.
            /// </summary>
            public static Rad<T> Atan2(T i_y, T i_x)
            {
                return (Rad<T>)T.Atan2(i_y, i_x);
            }

            /// <summary>
            /// Computes the sine of the angle.
            /// </summary>
            public static T Sin(Rad<T> i_radians)
            {
                return T.Sin((T)i_radians);
            }

            /// <summary>
            /// Computes the cosine of the angle.
            /// </summary>
            public static T Cos(Rad<T> i_radians)
            {
                return T.Cos((T)i_radians);
            }

            /// <summary>
            /// Computes the tangent of the angle.
            /// </summary>
            public static T Tan(Rad<T> i_radians)
            {
                return T.Tan((T)i_radians);
            }

            #endregion
        }
    }
}
