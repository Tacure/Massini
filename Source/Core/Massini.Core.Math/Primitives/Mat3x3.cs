
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using Massini.Math.Primitives;

namespace Massini.Math.Primitives
{
    public partial struct Mat3x3<T>
        where T : unmanaged, IFloatingPointIeee754<T>
    {
        /// <summary>
        /// The first row of the matrix.
        /// </summary>
        public Vec3<T> p_row0;

        /// <summary>
        /// The second row of the matrix.
        /// </summary>
        public Vec3<T> p_row1;

        /// <summary>
        /// The third row of the matrix.
        /// </summary>
        public Vec3<T> p_row2;

        public Mat3x3(Vec3<T> i_row0, Vec3<T> i_row1, Vec3<T> i_row2)
        {
            p_row0 = i_row0;
            p_row1 = i_row1;
            p_row2 = i_row2;
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
                    2 => p_row2[idx],
                    _ => throw new IndexOutOfRangeException()
                };
            }
            set
            {
                int idx = i_idx.GetOffset(Width);
                int idy = i_idy.GetOffset(Height);
                switch (idy)
                {
                    case 0: p_row0[idx] = value; break;
                    case 1: p_row1[idx] = value; break;
                    case 2: p_row2[idx] = value; break;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }

        public static Vec3<T> operator *(Mat3x3<T> i_matrix, Vec3<T> i_vector)
        {
            return new(
                i_vector.p_x * i_matrix.p_row0.p_x + i_vector.p_y * i_matrix.p_row0.p_y + i_vector.p_z * i_matrix.p_row0.p_z,
                i_vector.p_x * i_matrix.p_row1.p_x + i_vector.p_y * i_matrix.p_row1.p_y + i_vector.p_z * i_matrix.p_row1.p_z,
                i_vector.p_x * i_matrix.p_row2.p_x + i_vector.p_y * i_matrix.p_row2.p_y + i_vector.p_z * i_matrix.p_row2.p_z);
        }

        public static Mat3x3<T> operator *(Mat3x3<T> left, Mat3x3<T> right)
        {
            return new(
                left.p_row0[0] * right.p_row0 + left.p_row0[1] * right.p_row1 + left.p_row0[2] * right.p_row2,
                left.p_row1[0] * right.p_row0 + left.p_row1[1] * right.p_row1 + left.p_row1[2] * right.p_row2,
                left.p_row2[0] * right.p_row0 + left.p_row2[1] * right.p_row1 + left.p_row2[2] * right.p_row2);
        }

        public static bool operator ==(Mat3x3<T> left, Mat3x3<T> right)
        {
            return left.p_row0 == right.p_row0 && left.p_row1 == right.p_row1 && left.p_row2 == right.p_row2;
        }

        public static bool operator !=(Mat3x3<T> left, Mat3x3<T> right)
        {
            return left.p_row0 != right.p_row0 || left.p_row1 != right.p_row1 || left.p_row2 != right.p_row2;
        }

        public static Mat3x3<T> Zero => new(Vec3<T>.Zero, Vec3<T>.Zero, Vec3<T>.Zero);

        public static Mat3x3<T> Identity => new(Vec3<T>.UnitX, Vec3<T>.UnitY, Vec3<T>.UnitZ);

        public readonly int Width => 3;

        public readonly int Height => 3;

        public bool Equals(Mat3x3<T> other)
        {
            return this == other;
        }

        /// <inheritdoc/>
        public readonly override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj is Mat3x3<T> other)
            {
                return this == other;
            }
            return false;
        }

        /// <inheritdoc/>
        public readonly override int GetHashCode()
        {
            return HashCode.Combine(p_row0, p_row1, p_row2);
        }

        /// <inheritdoc/>
        public readonly override string ToString()
        {
            return $"[R0: {p_row0} R1: {p_row1} R2: {p_row2}]";
        }
    }

    public static class Mat3x3
    {
        extension<T>(Mat3x3<T>)
            where T : unmanaged, IFloatingPointIeee754<T>
        {
            #region Constructor Methods.

            /// <summary>
            /// This function builds up a rotation matrix from a quaternion.
            /// </summary>
            /// <param name="i_quat">Input quaternion</param>
            /// <returns>Rotation matrix</returns>
            public static Mat3x3<T> CreateRotationMatrixFromQuaternion(Quat<T> i_quat)
            {
                Mat3x3<T> rotMatrix = new();

                T two = Math<T>.Two;

                rotMatrix.p_row0.p_x = T.One - two * (i_quat.p_y * i_quat.p_y + i_quat.p_z * i_quat.p_z);
                rotMatrix.p_row0.p_y = two * (i_quat.p_x * i_quat.p_y - i_quat.p_z * i_quat.p_w);
                rotMatrix.p_row0.p_z = two * (i_quat.p_x * i_quat.p_z + i_quat.p_y * i_quat.p_w);

                rotMatrix.p_row1.p_x = two * (i_quat.p_x * i_quat.p_y + i_quat.p_z * i_quat.p_w);
                rotMatrix.p_row1.p_y = T.One - two * (i_quat.p_x * i_quat.p_x + i_quat.p_z * i_quat.p_z);
                rotMatrix.p_row1.p_z = two * (i_quat.p_y * i_quat.p_z - i_quat.p_x * i_quat.p_w);

                rotMatrix.p_row2.p_x = two * (i_quat.p_x * i_quat.p_z - i_quat.p_y * i_quat.p_w);
                rotMatrix.p_row2.p_y = two * (i_quat.p_y * i_quat.p_z + i_quat.p_x * i_quat.p_w);
                rotMatrix.p_row2.p_z = T.One - two * (i_quat.p_x * i_quat.p_x + i_quat.p_y * i_quat.p_y);

                return rotMatrix;
            }

            // Euler angle-axis sequences:
            // 
            // xyz      yzx     zxy
            // xzy      yxz     zyx (*)
            // xyx      yzy     zxz
            // xzx      yxy     zyz

            /// <summary>
            /// This function takes a ZYX Euler angles sequence and returns the respective matrix rotation.
            /// This matrix represents the following rotations:
            /// First rotation: psi angle around z axis.
            /// Second rotation: theta angle around y axis.
            /// Third rotation: phi angle around x axis.
            /// The vector parameter coordinates (v1, v2, v3) corresponds to the angles (phi, theta, psi) accordingly.
            /// </summary>
            /// <param name="i_angles"></param>
            /// <returns></returns>
            public static Mat3x3<T> CreateRotationMatrixZYXEulerAngles(Rad3<T> i_angles)
            {
                Vec3<T> row1 = new(Rad<T>.Cos(i_angles.p_psi) * Rad<T>.Cos(i_angles.p_theta),
                                Rad<T>.Cos(i_angles.p_psi) * Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_phi) - Rad<T>.Sin(i_angles.p_psi) * Rad<T>.Cos(i_angles.p_phi),
                                Rad<T>.Cos(i_angles.p_psi) * Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_phi) + Rad<T>.Sin(i_angles.p_psi) * Rad<T>.Sin(i_angles.p_phi));

                Vec3<T> row2 = new(Rad<T>.Sin(i_angles.p_psi) * Rad<T>.Cos(i_angles.p_theta),
                                Rad<T>.Sin(i_angles.p_psi) * Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_phi) + Rad<T>.Cos(i_angles.p_psi) * Rad<T>.Cos(i_angles.p_phi),
                                Rad<T>.Sin(i_angles.p_psi) * Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_phi) - Rad<T>.Cos(i_angles.p_psi) * Rad<T>.Sin(i_angles.p_phi));

                Vec3<T> row3 = new(-Rad<T>.Sin(i_angles.p_theta),
                                    Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_phi),
                                    Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_phi));

                return new Mat3x3<T>(row1, row2, row3);
            }

            /// <summary>
            /// This function takes a XYZ Euler angles sequence and returns the respective matrix rotation.
            /// This matrix represents the following rotations:
            /// First rotation: psi angle around x axis.
            /// Second rotation: theta angle around y axis.
            /// Third rotation: phi angle around z axis.
            /// The vector parameter coordinates (v1, v2, v3) corresponds to the angles (phi, theta, psi) accordingly.
            /// </summary>
            /// <param name="i_angles"></param>
            /// <returns></returns>
            public static Mat3x3<T> CreateRotationMatrixXYZEulerAngles(Rad3<T> i_angles)
            {
                Vec3<T> row1 = new(Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta),
                                -Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta),
                                Rad<T>.Sin(i_angles.p_theta));

                Vec3<T> row2 = new(Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi) + Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_psi),
                                -Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi) + Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_psi),
                                -Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi));

                Vec3<T> row3 = new(-Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi) + Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_psi),
                                    Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi) + Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_psi),
                                    Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi));

                return new Mat3x3<T>(row1, row2, row3);
            }

            /// <summary>
            /// This function takes a XZY Euler angles sequence and returns the respective matrix rotation.
            /// This matrix represents the following rotations:
            /// First rotation: psi angle around x axis.
            /// Second rotation: theta angle around z axis.
            /// Third rotation: phi angle around y axis.
            /// The vector parameter coordinates (v1, v2, v3) corresponds to the angles (phi, theta, psi) accordingly.
            /// </summary>
            /// <param name="i_angles"></param>
            /// <returns></returns>
            public static Mat3x3<T> CreateRotationMatrixXZYEulerAngles(Rad3<T> i_angles)
            {
                Vec3<T> row1 = new(Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta),
                                -Rad<T>.Sin(i_angles.p_theta),
                                Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta));

                Vec3<T> row2 = new(Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi) + Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_psi),
                                Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi),
                                Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi) - Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_psi));

                Vec3<T> row3 = new(Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi) - Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_psi),
                                Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi),
                                Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi) + Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_psi));

                return new Mat3x3<T>(row1, row2, row3);
            }

            /// <summary>
            /// This function takes a XYX Euler angles sequence and returns the respective matrix rotation.
            /// This matrix represents the following rotations:
            /// First rotation: psi angle around x axis.
            /// Second rotation: theta angle around y axis.
            /// Third rotation: phi angle around x axis.
            /// The vector parameter coordinates (v1, v2, v3) corresponds to the angles (phi, theta, psi) accordingly.
            /// </summary>
            /// <param name="i_angles"></param>
            /// <returns></returns>
            public static Mat3x3<T> CreateRotationMatrixXYXEulerAngles(Rad3<T> i_angles)
            {
                Vec3<T> row1 = new(Rad<T>.Cos(i_angles.p_theta),
                                Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta),
                                Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta));

                Vec3<T> row2 = new(Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi),
                                Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_psi) - Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi),
                                -Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_psi) - Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi));

                Vec3<T> row3 = new(-Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi),
                                    Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_psi) + Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi),
                                -Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_psi) + Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi));

                return new Mat3x3<T>(row1, row2, row3);
            }

            /// <summary>
            /// This function takes a XZX Euler angles sequence and returns the respective matrix rotation.
            /// This matrix represents the following rotations:
            /// First rotation: psi angle around x axis.
            /// Second rotation: theta angle around z axis.
            /// Third rotation: phi angle around x axis.
            /// The vector parameter coordinates (v1, v2, v3) corresponds to the angles (phi, theta, psi) accordingly.
            /// </summary>
            /// <param name="i_angles"></param>
            /// <returns></returns>
            public static Mat3x3<T> CreateRotationMatrixXZXEulerAngles(Rad3<T> i_angles)
            {
                Vec3<T> row1 = new(Rad<T>.Cos(i_angles.p_theta),
                                -Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta),
                                Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta));

                Vec3<T> row2 = new(Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi),
                                Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi) - Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_psi),
                                -Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi) - Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_psi));

                Vec3<T> row3 = new(Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi),
                                Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi) + Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_psi),
                                -Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi) + Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_psi));

                return new Mat3x3<T>(row1, row2, row3);
            }

            /// <summary>
            /// This function takes a YZX Euler angles sequence and returns the respective matrix rotation.
            /// This matrix represents the following rotations:
            /// First rotation: psi angle around y axis.
            /// Second rotation: theta angle around z axis.
            /// Third rotation: phi angle around x axis.
            /// The vector parameter coordinates (v1, v2, v3) corresponds to the angles (phi, theta, psi) accordingly.
            /// </summary>
            /// <param name="i_angles"></param>
            /// <returns></returns>
            public static Mat3x3<T> CreateRotationMatrixYZXEulerAngles(Rad3<T> i_angles)
            {
                Vec3<T> row1 = new(Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi),
                                -Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi) + Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_psi),
                                Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi) + Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_psi));

                Vec3<T> row2 = new(Rad<T>.Sin(i_angles.p_theta),
                                Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta),
                                -Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta));

                Vec3<T> row3 = new(-Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi),
                                    Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi) + Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_psi),
                                -Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi) + Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_psi));

                return new Mat3x3<T>(row1, row2, row3);
            }

            /// <summary>
            /// This function takes a YXZ Euler angles sequence and returns the respective matrix rotation.
            /// This matrix represents the following rotations:
            /// First rotation: psi angle around y axis.
            /// Second rotation: theta angle around x axis.
            /// Third rotation: phi angle around z axis.
            /// The vector parameter coordinates (v1, v2, v3) corresponds to the angles (phi, theta, psi) accordingly.
            /// </summary>
            /// <param name="i_angles"></param>
            /// <returns></returns>
            public static Mat3x3<T> CreateRotationMatrixYXZEulerAngles(Rad3<T> i_angles)
            {
                Vec3<T> row1 = new(Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_psi) + Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi),
                                -Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_psi) + Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi),
                                Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi));

                Vec3<T> row2 = new(Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta),
                                Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta),
                                -Rad<T>.Sin(i_angles.p_theta));

                Vec3<T> row3 = new(-Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_psi) + Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi),
                                    Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_psi) + Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi),
                                    Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi));

                return new Mat3x3<T>(row1, row2, row3);
            }

            /// <summary>
            /// This function takes a YZY Euler angles sequence and returns the respective matrix rotation.
            /// This matrix represents the following rotations:
            /// First rotation: psi angle around y axis.
            /// Second rotation: theta angle around z axis.
            /// Third rotation: phi angle around y axis.
            /// The vector parameter coordinates (v1, v2, v3) corresponds to the angles (phi, theta, psi) accordingly.
            /// </summary>
            /// <param name="i_angles"></param>
            /// <returns></returns>
            public static Mat3x3<T> CreateRotationMatrixYZYEulerAngles(Rad3<T> i_angles)
            {
                Vec3<T> row1 = new(Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi) - Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_psi),
                                -Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi),
                                Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi) + Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_psi));

                Vec3<T> row2 = new(Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta),
                                Rad<T>.Cos(i_angles.p_theta),
                                Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta));

                Vec3<T> row3 = new(-Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi) - Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_psi),
                                    Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi),
                                -Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi) + Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_psi));

                return new Mat3x3<T>(row1, row2, row3);
            }

            /// <summary>
            /// This function takes a YXY Euler angles sequence and returns the respective matrix rotation.
            /// This matrix represents the following rotations:
            /// First rotation: psi angle around y axis.
            /// Second rotation: theta angle around x axis.
            /// Third rotation: phi angle around y axis.
            /// The vector parameter coordinates (v1, v2, v3) corresponds to the angles (phi, theta, psi) accordingly.
            /// </summary>
            /// <param name="i_angles"></param>
            /// <returns></returns>
            public static Mat3x3<T> CreateRotationMatrixYXYEulerAngles(Rad3<T> i_angles)
            {
                Vec3<T> row1 = new(Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_psi) - Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi),
                                Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi),
                                Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_psi) + Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi));

                Vec3<T> row2 = new(Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta),
                                Rad<T>.Cos(i_angles.p_theta),
                                -Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta));

                Vec3<T> row3 = new(-Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_psi) - Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi),
                                    Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi),
                                -Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_psi) + Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi));

                return new Mat3x3<T>(row1, row2, row3);
            }

            /// <summary>
            /// This function takes a ZXY Euler angles sequence and returns the respective matrix rotation.
            /// This matrix represents the following rotations:
            /// First rotation: psi angle around z axis.
            /// Second rotation: theta angle around x axis.
            /// Third rotation: phi angle around y axis.
            /// The vector parameter coordinates (v1, v2, v3) corresponds to the angles (phi, theta, psi) accordingly.
            /// </summary>
            /// <param name="i_angles"></param>
            /// <returns></returns>
            public static Mat3x3<T> CreateRotationMatrixZXYEulerAngles(Rad3<T> i_angles)
            {
                Vec3<T> row1 = new(Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_psi) - Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi),
                                -Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi),
                                Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_psi) + Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi));

                Vec3<T> row2 = new(Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_psi) + Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi),
                                Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi),
                                Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_psi) - Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi));

                Vec3<T> row3 = new(-Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta),
                                    Rad<T>.Sin(i_angles.p_theta),
                                    Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta));

                return new Mat3x3<T>(row1, row2, row3);
            }

            /// <summary>
            /// This function takes a ZXZ Euler angles sequence and returns the respective matrix rotation.
            /// This matrix represents the following rotations:
            /// First rotation: psi angle around z axis.
            /// Second rotation: theta angle around x axis.
            /// Third rotation: phi angle around z axis.
            /// The vector parameter coordinates (v1, v2, v3) corresponds to the angles (phi, theta, psi) accordingly.
            /// </summary>
            /// <param name="i_angles"></param>
            /// <returns></returns>
            public static Mat3x3<T> CreateRotationMatrixZXZEulerAngles(Rad3<T> i_angles)
            {
                Vec3<T> row1 = new(Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_psi) - Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi),
                                -Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_psi) - Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi),
                                Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi));

                Vec3<T> row2 = new(Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_psi) + Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi),
                                -Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_psi) + Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi),
                                -Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi));

                Vec3<T> row3 = new(Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta),
                                Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta),
                                Rad<T>.Cos(i_angles.p_theta));

                return new Mat3x3<T>(row1, row2, row3);
            }

            /// <summary>
            /// This function takes a ZYZ Euler angles sequence and returns the respective matrix rotation.
            /// This matrix represents the following rotations:
            /// First rotation: psi angle around z axis.
            /// Second rotation: theta angle around y axis.
            /// Third rotation: phi angle around z axis.
            /// The vector parameter coordinates (v1, v2, v3) corresponds to the angles (phi, theta, psi) accordingly.
            /// </summary>
            /// <param name="i_angles"></param>
            /// <returns></returns>
            public static Mat3x3<T> CreateRotationMatrixZYZEulerAngles(Rad3<T> i_angles)
            {
                Vec3<T> row1 = new(Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi) - Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_psi),
                                -Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi) - Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_psi),
                                Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Cos(i_angles.p_psi));

                Vec3<T> row2 = new(Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi) + Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_psi),
                                -Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi) + Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Cos(i_angles.p_psi),
                                Rad<T>.Sin(i_angles.p_theta) * Rad<T>.Sin(i_angles.p_psi));

                Vec3<T> row3 = new(-Rad<T>.Cos(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta),
                                    Rad<T>.Sin(i_angles.p_phi) * Rad<T>.Sin(i_angles.p_theta),
                                    Rad<T>.Cos(i_angles.p_theta));

                return new Mat3x3<T>(row1, row2, row3);
            }

            #endregion

            #region Basic methods.

            /// <summary>
            /// This function receives a 3x3 matrix and returns the matrix determinant.
            /// </summary>
            public static T Determinant(Mat3x3<T> i_matrix)
            {
                return
                    (i_matrix.p_row0.p_x * i_matrix.p_row1.p_y * i_matrix.p_row2.p_z) +
                    (i_matrix.p_row1.p_x * i_matrix.p_row2.p_y * i_matrix.p_row0.p_z) +
                    (i_matrix.p_row0.p_y * i_matrix.p_row1.p_z * i_matrix.p_row2.p_x) -
                    (i_matrix.p_row0.p_z * i_matrix.p_row1.p_y * i_matrix.p_row2.p_x) -
                    (i_matrix.p_row0.p_y * i_matrix.p_row1.p_x * i_matrix.p_row2.p_z) -
                    (i_matrix.p_row0.p_x * i_matrix.p_row1.p_z * i_matrix.p_row2.p_y);
            }

            /// <summary>
            /// This function receives a 3x3 matrix and returns the matrix transpose.
            /// </summary>
            public static Mat3x3<T> Transpose(Mat3x3<T> i_matrix)
            {
                return new Mat3x3<T>()
                {
                    p_row0 = new(i_matrix.p_row0.p_x, i_matrix.p_row1.p_x, i_matrix.p_row2.p_x),
                    p_row1 = new(i_matrix.p_row0.p_y, i_matrix.p_row1.p_y, i_matrix.p_row2.p_y),
                    p_row2 = new(i_matrix.p_row0.p_z, i_matrix.p_row1.p_z, i_matrix.p_row2.p_z)
                };
            }

            /// <summary>
            /// This function receives a 3x3 matrix and returns its trace.
            /// </summary>
            public static T Trace(Mat3x3<T> i_matrix)
            {
                return i_matrix.p_row0.p_x + i_matrix.p_row1.p_y + i_matrix.p_row2.p_z;
            }

            /// <summary>
            /// This function receives a 3x3 matrix and returns its cofactor matrix.
            /// </summary>
            public static Mat3x3<T> Cofactor(Mat3x3<T> i_matrix)
            {
                T m00 = Math<T>.Determinant(new Mat2x2<T>(i_matrix.p_row1.p_y, i_matrix.p_row1.p_z, i_matrix.p_row2.p_y, i_matrix.p_row2.p_z));
                T m01 = Math<T>.Determinant(new Mat2x2<T>(i_matrix.p_row1.p_x, i_matrix.p_row1.p_z, i_matrix.p_row2.p_x, i_matrix.p_row2.p_z));
                T m02 = Math<T>.Determinant(new Mat2x2<T>(i_matrix.p_row1.p_x, i_matrix.p_row1.p_y, i_matrix.p_row2.p_x, i_matrix.p_row2.p_y));

                T m10 = Math<T>.Determinant(new Mat2x2<T>(i_matrix.p_row0.p_y, i_matrix.p_row0.p_z, i_matrix.p_row2.p_y, i_matrix.p_row2.p_z));
                T m11 = Math<T>.Determinant(new Mat2x2<T>(i_matrix.p_row0.p_x, i_matrix.p_row0.p_z, i_matrix.p_row2.p_x, i_matrix.p_row2.p_z));
                T m12 = Math<T>.Determinant(new Mat2x2<T>(i_matrix.p_row0.p_x, i_matrix.p_row0.p_y, i_matrix.p_row2.p_x, i_matrix.p_row2.p_y));

                T m20 = Math<T>.Determinant(new Mat2x2<T>(i_matrix.p_row0.p_y, i_matrix.p_row0.p_z, i_matrix.p_row1.p_y, i_matrix.p_row1.p_z));
                T m21 = Math<T>.Determinant(new Mat2x2<T>(i_matrix.p_row0.p_x, i_matrix.p_row0.p_z, i_matrix.p_row1.p_x, i_matrix.p_row1.p_z));
                T m22 = Math<T>.Determinant(new Mat2x2<T>(i_matrix.p_row0.p_x, i_matrix.p_row0.p_y, i_matrix.p_row1.p_x, i_matrix.p_row1.p_y));

                // Matrix of cofactors (note the sign pattern)
                // + - +
                // - + -
                // + - +
                Mat3x3<T> cofactorMatrix = new()
                {
                    p_row0 = new(m00, -m01, m02),
                    p_row1 = new(-m10, m11, -m12),
                    p_row2 = new(m20, -m21, m22)
                };

                return cofactorMatrix;
            }

            /// <summary>
            /// This function receives a 3x3 matrix and returns its adjugate (adjoint) matrix.
            /// The adjugate matrix is the transpose of the cofactor matrix.
            /// </summary>
            /// <returns>The adjugate matrix.</returns>
            public static Mat3x3<T> Adjoint(Mat3x3<T> i_matrix)
            {
                // Adjoint is the transpose of the cofactor matrix
                return Transpose(Cofactor(i_matrix));
            }

            /// <summary>
            /// This function receives a 3x3 matrix and returns its inverse.
            /// Throws an InvalidOperationException if the determinant is zero.
            /// </summary>
            /// <returns>The inverse of the matrix.</returns>
            public static Mat3x3<T> Inverse(Mat3x3<T> i_matrix)
            {
                T determinant = Determinant(i_matrix);
                Mat3x3<T> adjoint = Adjoint(i_matrix);

                // Multiply each element of the adjoint by (1 / determinant)
                T oneOverDeterminant = T.One / determinant;

                return new Mat3x3<T>()
                {
                    p_row0 = new(adjoint.p_row0.p_x * oneOverDeterminant,
                                adjoint.p_row0.p_y * oneOverDeterminant,
                                adjoint.p_row0.p_z * oneOverDeterminant),
                    p_row1 = new(adjoint.p_row1.p_x * oneOverDeterminant,
                                adjoint.p_row1.p_y * oneOverDeterminant,
                                adjoint.p_row1.p_z * oneOverDeterminant),
                    p_row2 = new(adjoint.p_row2.p_x * oneOverDeterminant,
                                adjoint.p_row2.p_y * oneOverDeterminant,
                                adjoint.p_row2.p_z * oneOverDeterminant)
                };
            }

            /// <summary>
            /// This function checks wether a 3x3 matrix is a rotation matrix,
            /// and returns true if it is the case, false if not.
            /// </summary>
            public static bool IsRotationMatrix(Mat3x3<T> i_matrix, T i_delta)
            {
                Mat3x3<T> mat3x3 = Transpose(i_matrix);

                bool detOne = Math<T>.NearlyEqual(Determinant(i_matrix), T.One, i_delta);
                bool matrixByTranspose = NearlyEqual(mat3x3 * i_matrix, Mat3x3<T>.Identity, i_delta);

                return detOne && matrixByTranspose;
            }

            #endregion

            #region Comparison methods.

            /// <summary>
            /// Returns true if the 3x3 matrices are nearly equal.
            /// </summary>
            /// <param name="i_mat2"></param>
            /// <param name="i_delta"></param>
            /// <returns></returns>
            public static bool NearlyEqual(Mat3x3<T> i_matrix, Mat3x3<T> i_mat2, T i_delta)
            {
                return
                    Vec3<T>.NearlyEqual(i_matrix.p_row0, i_mat2.p_row0, i_delta) &&
                    Vec3<T>.NearlyEqual(i_matrix.p_row1, i_mat2.p_row1, i_delta) &&
                    Vec3<T>.NearlyEqual(i_matrix.p_row2, i_mat2.p_row2, i_delta);
            }

            #endregion

            #region Rotation methods.

            /// <summary>
            /// This function receives a rotation matrix and returns the asociated fixed rotation axis.
            /// </summary>
            public static Vec3<T> FixedAxisFromRotationMatrix(Mat3x3<T> i_matrix)
            {
                // One way
                T v1 = i_matrix.p_row0.p_y * i_matrix.p_row1.p_z - (i_matrix.p_row1.p_y - T.One) * i_matrix.p_row0.p_z;
                T v2 = i_matrix.p_row1.p_x * i_matrix.p_row0.p_z - (i_matrix.p_row0.p_x - T.One) * i_matrix.p_row1.p_z;
                T v3 = (i_matrix.p_row0.p_x - T.One) * (i_matrix.p_row1.p_y - T.One) - i_matrix.p_row0.p_y * i_matrix.p_row1.p_x;

                // Another way
                //T v1 = i_this.p_row1.p_z - i_this.p_row2.p_y;
                //T v2 = i_this.p_row2.p_x - i_this.p_row0.p_z;
                //T v3 = i_this.p_row0.p_y - i_this.p_row1.p_x;

                Vec3<T> vec3 = Vec3<T>.Normalize(new Vec3<T>(v1, v2, v3));

                return vec3;
            }

            /// <summary>
            /// This function receives a rotation matrix and returns its rotation angle.
            /// </summary>
            public static Rad<T> AngleFromRotationMatrix(Mat3x3<T> i_matrix)
            {
                return Rad<T>.Acos((Trace(i_matrix) - T.One) / Math<T>.Two);
            }

            #endregion
        }
    }
}
