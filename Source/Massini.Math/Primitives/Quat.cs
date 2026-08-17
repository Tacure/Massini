using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;
using Massini.Math.Primitives;

namespace Massini.Math.Primitives
{
    [StructLayout(LayoutKind.Sequential)]
    public partial struct Quat<T>
        where T : unmanaged, IFloatingPointIeee754<T>
    {
        /// <summary>
        /// I coefficient of the quaternion.
        /// </summary>
        public T p_x = T.Zero;

        /// <summary>
        /// J coefficient of the quaternion.
        /// </summary>
        public T p_y = T.Zero;

        /// <summary>
        /// K coefficient of the quaternion.
        /// </summary>
        public T p_z = T.Zero;

        /// <summary>
        /// Real part of the quaternion.
        /// </summary>
        public T p_w = T.Zero;

        public Quat() { }

        public Quat(T i_x, T i_y, T i_z, T i_w)
        {
            p_x = i_x;
            p_y = i_y;
            p_z = i_z;
            p_w = i_w;
        }

        public static Quat<T> operator +(Quat<T> i_quat1, Quat<T> i_quat2)
            => new(i_quat1.p_x + i_quat2.p_x, i_quat1.p_y + i_quat2.p_y, i_quat1.p_z + i_quat2.p_z, i_quat1.p_w + i_quat2.p_w);

        public static Quat<T> operator -(Quat<T> i_quat1, Quat<T> i_quat2)
            => new(i_quat1.p_x - i_quat2.p_x, i_quat1.p_y - i_quat2.p_y, i_quat1.p_z - i_quat2.p_z, i_quat1.p_w - i_quat2.p_w);

        public static Quat<T> operator *(Quat<T> i_quat1, Quat<T> i_quat2)
            => new()
            {
                p_x = i_quat1.p_w * i_quat2.p_x + i_quat1.p_x * i_quat2.p_w + i_quat1.p_y * i_quat2.p_z - i_quat1.p_z * i_quat2.p_y,
                p_y = i_quat1.p_w * i_quat2.p_y + i_quat1.p_y * i_quat2.p_w + i_quat1.p_z * i_quat2.p_x - i_quat1.p_x * i_quat2.p_z,
                p_z = i_quat1.p_w * i_quat2.p_z + i_quat1.p_z * i_quat2.p_w + i_quat1.p_x * i_quat2.p_y - i_quat1.p_y * i_quat2.p_x,
                p_w = i_quat1.p_w * i_quat2.p_w - i_quat1.p_x * i_quat2.p_x - i_quat1.p_y * i_quat2.p_y - i_quat1.p_z * i_quat2.p_z
            };

        public static Quat<T> operator +(Quat<T> i_quat, T i_scalar)
            => new(i_quat.p_x + i_scalar, i_quat.p_y + i_scalar, i_quat.p_z + i_scalar, i_quat.p_w + i_scalar);

        public static Quat<T> operator +(T i_scalar, Quat<T> i_quat)
            => new(i_quat.p_x + i_scalar, i_quat.p_y + i_scalar, i_quat.p_z + i_scalar, i_quat.p_w + i_scalar);

        public static Quat<T> operator -(Quat<T> i_quat, T i_scalar)
            => new(i_quat.p_x - i_scalar, i_quat.p_y - i_scalar, i_quat.p_z - i_scalar, i_quat.p_w - i_scalar);

        public static Quat<T> operator -(T i_scalar, Quat<T> i_quat)
            => new(i_scalar - i_quat.p_x, i_scalar - i_quat.p_y, i_scalar - i_quat.p_z, i_scalar - i_quat.p_w);

        public static Quat<T> operator *(Quat<T> i_quat, T i_scalar)
            => new(i_quat.p_x * i_scalar, i_quat.p_y * i_scalar, i_quat.p_z * i_scalar, i_quat.p_w * i_scalar);

        public static Quat<T> operator *(T i_scalar, Quat<T> i_quat)
            => new(i_quat.p_x * i_scalar, i_quat.p_y * i_scalar, i_quat.p_z * i_scalar, i_quat.p_w * i_scalar);

        public static Quat<T> operator /(Quat<T> i_quat, T i_scalar)
            => new(i_quat.p_x / i_scalar, i_quat.p_y / i_scalar, i_quat.p_z / i_scalar, i_quat.p_w / i_scalar);

        public static Quat<T> operator /(T i_scalar, Quat<T> i_quat)
            => new(i_scalar / i_quat.p_x, i_scalar / i_quat.p_y, i_scalar / i_quat.p_z, i_scalar / i_quat.p_w);

        /// <summary>
        /// Returns a string representation of the quaternion.
        /// </summary>
        public readonly override string ToString()
        {
            return $"[X: {p_x} Y: {p_y} Z: {p_z} W: {p_w}]";
        }
    }

    public static class Quat
    {
        extension<T>(Quat<T>)
            where T : unmanaged, IFloatingPointIeee754<T>
        {
            #region Constructor methods.

            /// <summary>
            /// This function takes an axis and angle and returns the corresponding quaternion.
            /// </summary>
            public static Quat<T> CreateFromAxisAngle(Vec3<T> i_axis, T i_radians)
            {
                T two = Math<T>.Two;
                return new Quat<T>(
                i_axis.p_x * T.Sin(i_radians / two),
                i_axis.p_y * T.Sin(i_radians / two),
                i_axis.p_z * T.Sin(i_radians / two),
                T.Cos(i_radians / two));
            }

            /// <summary>
            /// This function takes an axis with angle vector and returns the corresponding quaternion.
            /// </summary>
            public static Quat<T> CreateFromRotationVector(Vec3<T> i_axisWithAngle)
            {
                Quat<T> quat = new();
                Vec3<T> unitAxis = Vec3<T>.Normalize(i_axisWithAngle);
                T angle = Vec3<T>.Magnitude(i_axisWithAngle);
                T two = Math<T>.Two;

                quat.p_x = unitAxis.p_x * T.Sin(angle / two);
                quat.p_y = unitAxis.p_y * T.Sin(angle / two);
                quat.p_z = unitAxis.p_z * T.Sin(angle / two);

                quat.p_w = T.Cos(angle / two);

                return quat;
            }

            /// <summary>
            /// This functions takes a rotation matrix and extracts the associated quaternion.
            /// </summary>
            /// <param name="i_mat"></param>
            /// <returns></returns>
            public static Quat<T> CreateFromRotationMatrix(Mat3x3<T> i_mat)
            {
                Quat<T> quat = new();

                T four = Math<T>.Four;

                quat.p_w = T.Sqrt(Mat3x3<T>.Trace(i_mat) + T.One) / Math<T>.Two;
                quat.p_x = (i_mat.p_row2.p_y - i_mat.p_row1.p_z) / (four * quat.p_w);
                quat.p_y = (i_mat.p_row0.p_z - i_mat.p_row2.p_x) / (four * quat.p_w);
                quat.p_z = (i_mat.p_row1.p_x - i_mat.p_row0.p_y) / (four * quat.p_w);

                return quat;
            }

            #endregion

            #region Basic methods.

            /// <summary>
            /// This function returns true if the parameter is a pure quaternion, and false if not.
            /// </summary>
            /// <returns>True or false value</returns>
            public static bool IsPure(Quat<T> i_quaternion)
            {
                return i_quaternion.p_w == T.Zero;
            }

            /// <summary>
            /// This function returns the quaterion norm.
            /// </summary>
            /// <returns>The quaternion norm</returns>
            public static T Norm(Quat<T> i_quaternion)
            {
                return T.Sqrt(i_quaternion.p_w * i_quaternion.p_w + i_quaternion.p_x * i_quaternion.p_x + i_quaternion.p_y * i_quaternion.p_y + i_quaternion.p_z * i_quaternion.p_z);
            }

            /// <summary>
            /// This function returns que conjugate quaternion.
            /// </summary>
            /// <returns>Quaternion conjugate</returns>
            public static Quat<T> Conjugate(Quat<T> i_quaternion)
            {
                return new Quat<T>(-i_quaternion.p_x, -i_quaternion.p_y, -i_quaternion.p_z, i_quaternion.p_w);
            }

            /// <summary>
            /// This function returns the quaternions dot product. 
            /// </summary>
            /// <param name="i_quat2">Second quaternion</param>
            /// <returns>Quaternion dot product result</returns>
            public static T Dot(Quat<T> i_quaternion, Quat<T> i_quat2)
            {
                return i_quaternion.p_x * i_quat2.p_x + i_quaternion.p_y * i_quat2.p_y + i_quaternion.p_z * i_quat2.p_z + i_quaternion.p_w * i_quat2.p_w;
            }

            /// <summary>
            /// This function takes a quaternion and normalizes it.
            /// </summary>
            /// <returns>Normalized quaternion</returns>
            public static Quat<T> Normalize(Quat<T> i_quaternion)
            {
                T d = i_quaternion.p_w * i_quaternion.p_w + i_quaternion.p_x * i_quaternion.p_x + i_quaternion.p_y * i_quaternion.p_y + i_quaternion.p_w * i_quaternion.p_w;
                Quat<T> quat = i_quaternion;

                // Check for zero length quaternion, and use the no-rotation
                // quaternion in that case.
                if (d < T.Epsilon)
                {
                    quat.p_w = T.One;
                    return quat;
                }

                d = T.One / Math<T>.Sqrt(d);

                quat.p_w *= d;
                quat.p_x *= d;
                quat.p_y *= d;
                quat.p_z *= d;

                return quat;
            }

            /// <summary>
            /// This function computes the quaternion logarithm.
            /// </summary>
            /// <returns>Quaternion logarithm</returns>
            public static Quat<T> Log(Quat<T> i_quaternion)
            {
                T norm = Norm(i_quaternion);
                Vec3<T> v = new(i_quaternion.p_x, i_quaternion.p_y, i_quaternion.p_z);
                T vMag = Vec3<T>.Magnitude(v);

                // Compute theta = acos(w / |q|)
                Rad<T> theta = Rad<T>.Acos(i_quaternion.p_w / norm);

                Vec3<T> vecPart = new(T.Zero, T.Zero, T.Zero);

                if (vMag >= T.Epsilon)
                {
                    vecPart = Vec3<T>.Normalize(v) * theta;
                }

                // Return log(q) = log(|q|) + theta * v̂
                return new Quat<T>(vecPart.p_x, vecPart.p_y, vecPart.p_z, Math<T>.Log(norm));
            }

            /// <summary>
            /// This function computes the quaternion exponential.
            /// </summary>
            /// <returns>Quaternion exponential</returns>
            public static Quat<T> Exp(Quat<T> i_quaternion)
            {
                Vec3<T> v = new(i_quaternion.p_x, i_quaternion.p_y, i_quaternion.p_z);
                T vMag = Vec3<T>.Magnitude(v);

                T expW = Math<T>.Pow(T.E, i_quaternion.p_w);

                T sinVMag, cosVMag;
                if (vMag >= T.Epsilon)
                {
                    sinVMag = Rad<T>.Sin((Rad<T>)vMag);
                    cosVMag = Rad<T>.Cos((Rad<T>)vMag);

                    Vec3<T> vPart = Vec3<T>.Normalize(v) * sinVMag;
                    return new(vPart.p_x * expW, vPart.p_y * expW, vPart.p_z * expW, cosVMag * expW);
                }
                else
                {
                    // If v is zero, exp(q) = exp(w)
                    return new(T.Zero, T.Zero, T.Zero, expW);
                }
            }

            #endregion

            #region Interpolation methods.

            /// <summary>
            /// This function implements quaternion linear interpolation.
            /// </summary>
            /// <param name="i_quat2">End quaternion</param>
            /// <param name="i_t">Interpolation parameter 0 < t < 1</param>
            /// <returns>Interpolated quaternion</returns>
            public static Quat<T> Lerp(Quat<T> i_quaternion, Quat<T> i_quat2, T i_t)
            {
                Debug.Assert(i_t >= T.Zero && i_t <= T.One, "Interpolation factor must be between 0 and 1.");

                return Normalize(i_quaternion * (T.One - i_t) + i_quat2 * i_t);
            }

            /// <summary>
            /// This function implements spherical linear interpolation for the shortest path.
            /// </summary>
            /// <param name="i_quaternion">Start quaternion</param>
            /// <param name="i_quat2">End quaternion</param>
            /// <param name="i_t">Interpolation parameter 0 < t < 1</param>
            /// <param name="i_minDelta">Minimum dot product difference between the quaternions to be considered nearly identical. Must be between 0 and 1.</param>
            /// <returns>Interpolated quaternion</returns>
            public static Quat<T> Slerp(Quat<T> i_quaternion, Quat<T> i_quat2, T i_t, T i_minDelta)
            {
                Debug.Assert(i_t >= T.Zero && i_t <= T.One, "Interpolation factor must be between 0 and 1.");
                Debug.Assert(i_minDelta >= T.Zero && i_minDelta <= T.One, "i_minDelta must be between 0 and 1.");

                T cos_omega = Dot(i_quaternion, i_quat2);

                // If the dot product is negative, negate q2 to take the shorter path.
                if (cos_omega < T.Zero)
                {
                    i_quat2 *= -T.One;
                    cos_omega = -cos_omega;
                }

                // It the quaternions are nearly identical, use linear interpolation.
                if (Math<T>.NearlyEqual(cos_omega, T.One, i_minDelta))
                {
                    return Lerp(i_quaternion, i_quat2, i_t);
                }

                // Calculate the angle between the quaternions.
                Rad<T> omega = Rad<T>.Acos(cos_omega);
                T sin_omega = Math<T>.Sqrt(T.One - cos_omega * cos_omega);

                // Compute the interpolations.
                T factor0 = Rad<T>.Sin((T.One - i_t) * omega) / sin_omega;
                T factor1 = Rad<T>.Sin(i_t * omega) / sin_omega;

                return Normalize((i_quaternion * factor0) + (i_quat2 * factor1));
            }

            /// <summary>
            /// This function implements spherical linear interpolation for the longest path.
            /// </summary>
            /// <param name="i_quaternion">Start quaternion</param>
            /// <param name="i_quat2">End quaternion</param>
            /// <param name="i_t">Interpolation parameter 0 < t < 1</param>
            /// <param name="i_minDelta">Minimum dot product difference between the quaternions to be considered nearly identical. Must be between 0 and 1.</param>
            /// <returns>Interpolated quaternion</returns>
            public static Quat<T> SlerpLongestPath(Quat<T> i_quaternion, Quat<T> i_quat2, T i_t, T i_minDelta)
            {
                Debug.Assert(i_t >= T.Zero && i_t <= T.One, "Interpolation factor must be between 0 and 1.");
                Debug.Assert(i_minDelta >= T.Zero && i_minDelta <= T.One, "i_minDelta must be between 0 and 1.");

                T cos_omega = Dot(i_quaternion, i_quat2);

                // If the dot product is positive, negate q2 to take the longest path.
                if (cos_omega >= T.Zero)
                {
                    i_quat2 *= -T.One;
                    cos_omega = -cos_omega;
                }

                // It the quaternions are nearly identical, use linear interpolation.
                if (Math<T>.NearlyEqual(cos_omega, T.One, i_minDelta))
                {
                    return Lerp(i_quaternion, i_quat2, i_t);
                }

                // Calculate the angle between the quaternions.
                Rad<T> omega = Rad<T>.Acos(cos_omega);
                T sin_omega = Math<T>.Sqrt(T.One - (cos_omega * cos_omega));

                // Compute the interpolations.
                T factor0 = Rad<T>.Sin((T.One - i_t) * omega) / sin_omega;
                T factor1 = Rad<T>.Sin(i_t * omega) / sin_omega;

                return Normalize((i_quaternion * factor0) + (i_quat2 * factor1));
            }

            /// <summary>
            /// This funtion implements spherical and quadrangle interpolation.
            /// </summary>
            /// <param name="i_quaternion">Start quaternion</param>
            /// <param name="i_quat2">End quaternion</param>
            /// <param name="i_quatA">Control quaternion</param>
            /// <param name="i_quatB">Control quaternion</param>
            /// <param name="i_t">Interpolation parameter 0 < t < 1</param>
            /// <param name="i_minDelta">Minimum dot product difference between the quaternions to be considered nearly identical. Must be between 0 and 1.</param>
            /// <returns>Interpolated quaternion</returns>
            public static Quat<T> SquadInterpolation(Quat<T> i_quaternion, Quat<T> i_quat2, Quat<T> i_quatA, Quat<T> i_quatB, T i_t, T i_minDelta)
            {
                Debug.Assert(i_t >= T.Zero && i_t <= T.One, "Interpolation factor must be between 0 and 1.");
                Debug.Assert(i_minDelta >= T.Zero && i_minDelta <= T.One, "i_minDelta must be between 0 and 1.");

                return Slerp(Slerp(i_quaternion, i_quatB, i_t, i_minDelta), Slerp(i_quatA, i_quat2, i_t, i_minDelta), Math<T>.Two * i_t * (T.One - i_t), i_minDelta);
            }

            /// <summary>
            /// This function computes a control quaternion for SQUAD interpolation.
            /// </summary>
            /// <param name="i_quaternion">Start quaternion</param>
            /// <param name="i_quat2">End quaternion</param>
            /// <param name="i_delta">Velocity or profile parameter</param>
            /// <returns>The control quaternion</returns>
            public static Quat<T> ComputeControlQuaternion(Quat<T> i_quaternion, Quat<T> i_quat2, T i_delta)
            {
                Quat<T> log_q = Log(i_quat2) - Log(i_quaternion);
                Quat<T> control = i_quaternion * Exp((T.Zero - log_q) * i_delta / Math<T>.Two);

                return control;
            }

            /// <summary>
            /// This function performs Catmull-Rom spline interpolation of quaternions.
            /// </summary>
            /// <param name="i_qCurrent">Current quaternion</param>
            /// <param name="i_qNext">Next quaternion</param>
            /// <param name="i_qPrev">Previous quaternion</param>
            /// <param name="i_qNext2">Next after next quaternion</param>
            /// <param name="i_t">Interpolation parameter 0 < t < 1</param>
            /// <returns>Interpolated quaternion</returns>
            public static Quat<T> CatmullRomSplineInterpolation(Quat<T> i_qCurrent, Quat<T> i_qNext, Quat<T> i_qPrev, Quat<T> i_qNext2, T i_t)
            {
                Debug.Assert(i_t >= T.Zero && i_t <= T.One, "Interpolation factor must be between 0 and 1.");

                T t2 = i_t * i_t;
                T t3 = t2 * i_t;
                T two = Math<T>.Two;
                T three = Math<T>.Three;
                return (i_qCurrent * (two * t3 - three * t2 + T.One) +
                    i_qNext * (-two * t3 + three * t2) +
                    i_qPrev * (t3 - two * t2 + i_t) +
                    i_qNext2 * (t3 - t2));
            }

            #endregion

            #region Rotation methods.

            /// <summary>
            /// This function extracts the angle of rotation in radians from a quaternion.
            /// </summary>
            /// <returns>Rotation angle</returns>
            public static T Angle(Quat<T> i_quaternion)
            {
                T two = Math<T>.Two;
                return T.Acos(i_quaternion.p_w) * two;
            }

            /// <summary>
            /// This function extracts a unit eigenvector from a quaternion.
            /// </summary>
            /// <returns>Eigenvector</returns>
            public static Vec3<T> Eigenvector(Quat<T> i_quaternion)
            {
                Vec3<T> eigenvector = new();
                T theta = Angle(i_quaternion);
                T two = Math<T>.Two;

                eigenvector.p_x = i_quaternion.p_x / T.Sin(theta / two);
                eigenvector.p_y = i_quaternion.p_y / T.Sin(theta / two);
                eigenvector.p_z = i_quaternion.p_z / T.Sin(theta / two);

                return eigenvector;
            }

            #endregion

            /*
            * Rotation matrix from quaternion as in the Rigid Body Dynamics book.
            * DON'T ERASE THIS COMMENTED MATRIX!!!
            * 
            rotMatrix.p_row0.p_x = T.One - two* (i_this.p_y* i_this.p_y + i_this.p_z* i_this.p_z);
            rotMatrix.p_row1.p_x = two* (i_this.p_x* i_this.p_y + i_this.p_z* i_this.p_w);
            rotMatrix.p_row2.p_x = two* (i_this.p_x* i_this.p_z - i_this.p_y* i_this.p_w);

            rotMatrix.p_row0.p_y = two* (i_this.p_x* i_this.p_y - i_this.p_z* i_this.p_w);
            rotMatrix.p_row1.p_y = T.One - two* (i_this.p_x* i_this.p_x + i_this.p_z* i_this.p_z);
            rotMatrix.p_row2.p_y = two* (i_this.p_y* i_this.p_z + i_this.p_x* i_this.p_w);

            rotMatrix.p_row0.p_z = two* (i_this.p_x* i_this.p_z + i_this.p_y* i_this.p_w);
            rotMatrix.p_row1.p_z = two* (i_this.p_y* i_this.p_z - i_this.p_x* i_this.p_w);
            rotMatrix.p_row2.p_z = T.One - two* (i_this.p_x* i_this.p_x + i_this.p_y* i_this.p_y);
            */
        }
    }
}
