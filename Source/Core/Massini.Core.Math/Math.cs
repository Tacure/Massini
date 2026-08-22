
using System.Numerics;

namespace Massini.Core.Math
{
    public static class Math<T>
        where T : unmanaged, INumber<T>
    {
        public static T Zero { get; private set; } = T.CreateChecked(0);

        public static T One { get; private set; } = T.CreateChecked(1);

        public static T Two { get; private set; } = T.CreateChecked(2);

        public static T Three { get; private set; } = T.CreateChecked(3);

        public static T Four { get; private set; } = T.CreateChecked(4);

        #region Basic methods.

        /// <summary>
        /// Returns true if the two values are nearly equal.
        /// </summary>
        public static bool NearlyEqual(T i_val1, T i_val2, T i_delta)
        {
            return T.Abs(i_val1 - i_val2) <= T.Abs(i_delta);
        }

        /// <summary>
        /// Returns true if the value is within the given range.
        /// </summary>
        public static bool IsInRange(T i_val, T i_min, T i_max)
        {
            return i_val >= i_min && i_val <= i_max;
        }

        /// <summary>
        /// Returns true if the value is outside the given range.
        /// </summary>
        public static bool IsNotInRange(T i_val, T i_min, T i_max)
        {
            return i_val < i_min || i_val > i_max;
        }

        /// <summary>
        /// Computes the absolute value of a number.
        /// </summary>
        public static T Abs(T i_val)
        {
            return T.Abs(i_val);
        }

        /// <summary>
        /// Returns the smallest value in the span.
        /// </summary>
        public static T Min(params ReadOnlySpan<T> i_values)
        {
            if (i_values.Length == 0)
            {
                throw new ArgumentException("Array size must be greater than 0.");
            }

            T min = T.Zero;
            for (int i = 1; i < i_values.Length; i++)
            {
                min = T.Min(i_values[0], i_values[i]);
            }
            return min;
        }

        /// <summary>
        /// Returns the biggest value in the span.
        /// </summary>
        public static T Max(params ReadOnlySpan<T> i_values)
        {
            if (i_values.Length == 0)
            {
                throw new ArgumentException("Array size must be greater than 0.");
            }

            T max = T.Zero;
            for (int i = 1; i < i_values.Length; i++)
            {
                max = T.Max(i_values[0], i_values[i]);
            }
            return max;
        }

        /// <summary>
        /// Returns true if the specified value is a prime number.
        /// </summary>
        public static bool IsPrime(T i_value)
        {
            if (i_value < T.CreateChecked(2)) return false;
            if (i_value == T.CreateChecked(2)) return true;
            if (i_value % T.CreateChecked(2) == T.Zero) return false;

            for (T divisor = T.CreateChecked(3); divisor * divisor <= i_value; divisor += T.CreateChecked(2))
            {
                if (i_value % divisor == T.Zero) return false;
            }
            return true;
        }

        public static void Swap(ref T i_val1, ref T i_val2)
        {
            T temp = i_val1;
            i_val1 = i_val2;
            i_val2 = temp;
        }

        #endregion
    }

    public static class Math
    {
        extension<T>(Math<T>)
            where T : unmanaged, IFloatingPointIeee754<T>
        {
            public static T Pi => T.Pi;

            public static T E => T.E;

            public static T Tau => T.Tau;

            public static T Phi => T.CreateTruncating(1.61803398874989484821);

            public static T Epsilon => T.Epsilon;

            /// <summary>
            /// Snaps the number to the nearest discrete value that is a multiple of the step.
            /// </summary>
            public static T Snap(T i_val, T i_step)
            {
                if (i_step == T.Zero)
                {
                    return i_val;
                }
                return Floor(i_val / i_step) * i_step;
            }

            /// <summary>
            /// Subtracts the value from 1.
            /// </summary>
            public static T OneMinus(T i_val)
            {
                return T.One - i_val;
            }

            /// <summary>
            /// Returns the remainder of the division.
            /// </summary>
            public static T Mod(T i_val1, T i_val2)
            {
                T r = i_val1 % i_val2;
                return r < T.Zero ? r + i_val2 : r;
            }

            /// <summary>
            /// Returns the fractional part of the value.
            /// </summary>
            public static T Fract(T i_val)
            {
                return i_val - Floor(i_val);
            }

            public static T Exp(T i_val)
            {
                return T.Exp(i_val);
            }

            /// <summary>
            /// Returns the sign of the value.
            /// </summary>
            public static int Sign(T i_val)
            {
                return T.Sign(i_val);
            }

            /// <summary>
            /// Returns the average of the specified values.
            /// </summary>
            public static T Average(params ReadOnlySpan<T> i_values)
            {
                T sum = T.Zero;
                for (int i = 0; i < i_values.Length; i++)
                {
                    sum += i_values[i];
                }
                return sum / T.CreateChecked(i_values.Length);
            }

            /// <summary>
            /// Returns the nearest integer to the specified number.
            /// </summary>
            public static T Round(T i_val)
            {
                return T.Round(i_val);
            }

            /// <summary>
            /// Returns the integer part of the specified number.
            /// </summary>
            public static T Truncate(T i_val)
            {
                return T.Truncate(i_val);
            }

            /// <summary>
            /// Returns the largest integer that is less than or equal to the specified number.
            /// </summary>
            public static T Floor(T i_val)
            {
                return T.Floor(i_val);
            }

            /// <summary>
            /// Returns the smallest integer that is greater than or equal to the specified number.
            /// </summary>
            public static T Ceiling(T i_val)
            {
                return T.Ceiling(i_val);
            }

            /// <summary>
            /// Clamps the value within the given range.
            /// </summary>
            public static T Clamp(T i_val, T i_min, T i_max)
            {
                return T.Clamp(i_val, i_min, i_max);
            }

            /// <summary>
            /// Computes the square root of a number.
            /// </summary>
            public static T Sqrt(T i_val)
            {
                return T.Sqrt(i_val);
            }

            /// <summary>
            /// Computes the power of a number.
            /// </summary>
            public static T Pow(T i_val, T i_exp)
            {
                return T.Pow(i_val, i_exp);
            }

            /// <summary>
            /// Computes the natural logarithm of a number.
            /// </summary>
            public static T Log(T i_val)
            {
                return T.Log(i_val);
            }

            /// <summary>
            /// Computes the base-10 logarithm of a number.
            /// </summary>
            public static T Log10(T i_val)
            {
                return T.Log10(i_val);
            }

            /// <summary>
            /// Linearly interpolates between two values.
            /// </summary>
            public static T Lerp(T i_from, T i_to, T i_alpha)
            {
                return (i_from * (T.One - i_alpha)) + (i_to * i_alpha);
            }

            /// <summary>
            /// Maps a value from a given range to a 0.0 to 1.0 range.
            /// </summary>
            /// <param name="i_val">The value to be mapped.</param>
            /// <param name="i_fromMin">The minimum value of the range to be mapped from.</param>
            /// <param name="i_fromMax">The maximum value of the range to be mapped from.</param>
            /// <param name="i_clamp">If true, the value will be clamped to the range.</param>
            /// <returns>The mapped value.</returns>
            public static T Map01(T i_val, T i_fromMin, T i_fromMax, bool i_clamp = false)
            {
                //https://prime31.github.io/simple-value-mapping/

                if (i_clamp) i_val = T.Clamp(i_val, i_fromMin, i_fromMax);

                if (i_fromMin == i_fromMax) return i_fromMax;

                return (i_val - i_fromMin) * T.One / (i_fromMax - i_fromMin);
            }

            /// <summary>
            /// Maps a value from a given range to another range.
            /// </summary>
            /// <param name="i_val">The value to be mapped.</param>
            /// <param name="i_fromMin">The minimum value of the range to be mapped from.</param>
            /// <param name="i_fromMax">The maximum value of the range to be mapped from.</param>
            /// <param name="i_toMin">The minimum value of the range to be mapped to.</param>
            /// <param name="i_toMax">The maximum value of the range to be mapped to.</param>
            /// <param name="i_clamp">If true, the value will be clamped to the range.</param>
            /// <returns>The mapped value.</returns>
            public static T Map(T i_val, T i_fromMin, T i_fromMax, T i_toMin, T i_toMax, bool i_clamp = false)
            {
                //https://prime31.github.io/simple-value-mapping/

                if (i_clamp) i_val = T.Clamp(i_val, i_fromMin, i_fromMax);

                if (i_fromMin == i_fromMax) return i_fromMax;

                return i_toMin + ((i_val - i_fromMin) * (i_toMax - i_toMin) / (i_fromMax - i_fromMin));
            }

            /// <summary>
            /// Computes the inverse square root of a number.
            /// </summary>
            /// <exception cref="ArgumentOutOfRangeException"></exception>
            public static T InverseSqrt(T i_val)
            {
                if (i_val == T.Zero)
                {
                    // Handle zero input. Inverse square root of zero is mathematically undefined (approaches infinity).
                    return T.PositiveInfinity;
                }

                if (T.IsNegative(i_val))
                {
                    throw new ArgumentOutOfRangeException(nameof(i_val), "Cannot compute inverse square root of a negative value for real number types.");
                }

                return T.One / Sqrt(i_val);
            }

            /// <summary>
            /// Returns the value that is the farthest from a reference value.
            /// </summary>
            public static T Farthest(T i_val1, T i_val2, T i_reference)
            {
                return T.Abs(i_val1 - i_reference) > T.Abs(i_val2 - i_reference) ? i_val1 : i_val2;
            }

            /// <summary>
            /// Returns the value that is the nearest to a reference value.
            /// </summary>
            public static T Nearest(T i_val1, T i_val2, T i_reference)
            {
                return T.Abs(i_val1 - i_reference) < T.Abs(i_val2 - i_reference) ? i_val1 : i_val2;
            }

            /// <summary>
            /// Smooth maximum. Returns the biggest value while smoothly mixing values that are close according to the threshold.
            /// </summary>
            public static T Smax(T i_val1, T i_val2, T i_factor)
            {
                // Reference: https://www.youtube.com/watch?v=6Qb6QtC6QMs
                return (i_val1 + i_val2 + Sabs(i_val1 - i_val2, i_factor)) / Math<T>.Two;
            }

            /// <summary>
            /// Smooth minimum. Returns the smallest value while smoothly mixing values that are close according to the threshold.
            /// </summary>
            public static T Smin(T i_val1, T i_val2, T i_factor)
            {
                // Reference: https://www.youtube.com/watch?v=6Qb6QtC6QMs
                return (i_val1 + i_val2 - Sabs(i_val1 - i_val2, i_factor)) / Math<T>.Two;
            }

            /// <summary>
            /// Computes the smooth absolute value by smoothing the sharp corner of the function near zero.
            /// </summary>
            /// <param name="i_val"></param>
            /// <param name="i_factor"></param>
            /// <returns></returns>
            public static T Sabs(T i_val, T i_factor)
            {
                // Reference: https://www.youtube.com/watch?v=6Qb6QtC6QMs
                return Math<T>.Abs(i_val) + (Pow(Math<T>.Max(i_factor - Math<T>.Abs(i_val), T.Zero), Math<T>.Two) / (Math<T>.Two * i_factor));
            }
        }
    }
}
