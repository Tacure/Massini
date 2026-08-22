
using System.Numerics;

namespace Massini.Core.Math.Primitives
{
    /// <summary>
    /// Represents an angle in degrees.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public readonly partial struct Deg<T>(T i_value)
        where T : unmanaged, IFloatingPointIeee754<T>
    {
        public static explicit operator T(Deg<T> i_value) => i_value.m_value;

        public static explicit operator Deg<T>(T i_value) => new(i_value);

        public static bool operator >(Deg<T> left, Deg<T> right)
        {
            return left.m_value > right.m_value;
        }

        public static bool operator >=(Deg<T> left, Deg<T> right)
        {
            return left.m_value >= right.m_value;
        }

        public static bool operator <(Deg<T> left, Deg<T> right)
        {
            return left.m_value < right.m_value;
        }

        public static bool operator <=(Deg<T> left, Deg<T> right)
        {
            return left.m_value <= right.m_value;
        }

        public static Deg<T> operator %(Deg<T> left, Deg<T> right)
        {
            return new(left.m_value % right.m_value);
        }

        public static Deg<T> operator +(Deg<T> left, Deg<T> right)
        {
            return new(left.m_value + right.m_value);
        }

        public static Deg<T> operator --(Deg<T> value)
        {
            return new(value.m_value - T.One);
        }

        public static Deg<T> operator /(Deg<T> left, Deg<T> right)
        {
            return new(left.m_value / right.m_value);
        }

        public static bool operator ==(Deg<T> left, Deg<T> right)
        {
            return left.m_value == right.m_value;
        }

        public static bool operator !=(Deg<T> left, Deg<T> right)
        {
            return left.m_value != right.m_value;
        }

        public static Deg<T> operator ++(Deg<T> value)
        {
            return new(value.m_value + T.One);
        }

        public static Deg<T> operator *(Deg<T> left, Deg<T> right)
        {
            return new(left.m_value * right.m_value);
        }

        public static Deg<T> operator *(Deg<T> i_degrees, T i_scalar)
        {
            return new(i_degrees.m_value * i_scalar);
        }

        public static Deg<T> operator *(T i_scalar, Deg<T> i_degrees)
        {
            return new(i_degrees.m_value * i_scalar);
        }

        public static Deg<T> operator /(Deg<T> i_degrees, T i_scalar)
        {
            return new(i_degrees.m_value / i_scalar);
        }

        public static Vec3<T> operator *(Deg<T> i_degrees, Vec3<T> i_vector)
        {
            return i_degrees.m_value * i_vector;
        }

        public static Vec3<T> operator *(Vec3<T> i_vector, Deg<T> i_degrees)
        {
            return i_vector * i_degrees.m_value;
        }

        public static Deg<T> operator -(Deg<T> left, Deg<T> right)
        {
            return new(left.m_value - right.m_value);
        }

        public static Deg<T> operator -(Deg<T> value)
        {
            return new(-value.m_value);
        }

        public static Deg<T> operator +(Deg<T> value)
        {
            return value;
        }

        public static Deg<T> Zero => new(T.Zero);

        public override bool Equals(object? i_obj)
        {
            return i_obj is Deg<T> other && this == other;
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

    public static class Deg
    {
        extension<T>(Deg<T>)
            where T : unmanaged, IFloatingPointIeee754<T>
        {
            /// <summary>
            /// Converts radians to degrees.
            /// </summary>
            public static Deg<T> RadiansToDegrees(Rad<T> i_radians)
            {
                return (Deg<T>)T.RadiansToDegrees((T)i_radians);
            }
        }
    }
}
