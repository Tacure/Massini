
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.InteropServices;
using Massini.Core.Math.Primitives;

namespace Massini.Core.Math.Primitives
{
    /// <summary>
    /// Represents a 2x2 matrix.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public partial struct Mat2x2<T>
        where T : unmanaged, IFloatingPointIeee754<T>
    {
        /// <summary>
        /// The first row of the matrix.
        /// </summary>
        public Vec2<T> p_row0;

        /// <summary>
        /// The second row of the matrix.
        /// </summary>
        public Vec2<T> p_row1;

        public Mat2x2(T i_r00, T i_r01, T i_r10, T i_r11)
        {
            p_row0 = new(i_r00, i_r01);
            p_row1 = new(i_r10, i_r11);
        }

        public Mat2x2(Vec2<T> i_row0, Vec2<T> i_row1)
        {
            p_row0 = i_row0;
            p_row1 = i_row1;
        }

        /// <inheritdoc/>
        public T this[Index i_idx, Index i_idy] 
        { 
            get 
            {
                int idx = i_idx.GetOffset(Width);
                int idy = i_idy.GetOffset(Height);
                return idy switch
                {
                    0 => p_row0[idx],
                    1 => p_row1[idx],
                    _ => throw new IndexOutOfRangeException()
                };
            }
            set 
            {
                int idx = i_idx.GetOffset(Width);
                int idy = i_idy.GetOffset(Height);
                switch(idy)
                {
                    case 0: p_row0[idx] = value; break;
                    case 1: p_row1[idx] = value; break;
                    default: throw new IndexOutOfRangeException();
                };
            }
        }

        public static Vec2<T> operator *(Mat2x2<T> i_matrix, Vec2<T> i_vector)
        {
            return new(
                i_vector.p_x * i_matrix.p_row0.p_x + i_vector.p_y * i_matrix.p_row0.p_y,
                i_vector.p_x * i_matrix.p_row1.p_x + i_vector.p_y * i_matrix.p_row1.p_y);
        }

        public static Mat2x2<T> operator *(Mat2x2<T> left, Mat2x2<T> right)
        {
            return new(
                left.p_row0[0] * right.p_row0 + left.p_row0[1] * right.p_row1,
                left.p_row1[0] * right.p_row0 + left.p_row1[1] * right.p_row1);
        }

        public static bool operator ==(Mat2x2<T> left, Mat2x2<T> right)
        {
            return left.p_row0 == right.p_row0 && left.p_row1 == right.p_row1;
        }

        public static bool operator !=(Mat2x2<T> left, Mat2x2<T> right)
        {
            return left.p_row0 != right.p_row0 || left.p_row1 != right.p_row1;
        }

        /// <inheritdoc/>
        public static Mat2x2<T> Zero => new(Vec2<T>.Zero, Vec2<T>.Zero);

        /// <inheritdoc/>
        public static Mat2x2<T> Identity => new(Vec2<T>.UnitX, Vec2<T>.UnitY);

        /// <inheritdoc/>
        public readonly int Width => 2;

        /// <inheritdoc/>
        public readonly int Height => 2;

        /// <inheritdoc/>
        public readonly bool Equals(Mat2x2<T> other)
        {
            return this == other;
        }

        /// <inheritdoc/>
        public readonly override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Mat2x2<T> other)
            {
                return this == other;
            }
            return false;
        }

        /// <inheritdoc/>
        public readonly override int GetHashCode()
        {
            return HashCode.Combine(p_row0, p_row1);
        }

        /// <inheritdoc/>
        public readonly override string ToString()
        {
            return $"[R0: {p_row0} R1: {p_row1}]";
        }
    }

    public static class Mat2x2
    {
        extension<T>(Math<T>)
            where T : unmanaged, IFloatingPointIeee754<T>
        {
            #region Basic Methods.

            /// <summary>
            /// This function receives a 2x2 matrix and returns the matrix determinant.
            /// </summary>
            public static T Determinant(Mat2x2<T> i_matrix)
            {
                // Determinant of a 2x2 matrix: | a b | = ad - bc
                //                              | c d |
                // In this struct: a = p_row0.p_x, b = p_row0.p_y
                //                 c = p_row1.p_x, d = p_row1.p_y
                return (i_matrix.p_row0.p_x * i_matrix.p_row1.p_y) - (i_matrix.p_row0.p_y * i_matrix.p_row1.p_x);
            }

            #endregion
        }
    }
}
