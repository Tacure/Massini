
using System.Numerics;
using Massini.Core.Math.Primitives;

namespace Massini.Core.Math.Primitives
{
    public partial struct Rad3<T>
        where T : unmanaged, IFloatingPointIeee754<T>
    {
        public Rad<T> p_phi = Rad<T>.Zero;
        public Rad<T> p_theta = Rad<T>.Zero;
        public Rad<T> p_psi = Rad<T>.Zero;

        public Rad3() { }

        public Rad3(Rad<T> i_phi, Rad<T> i_theta, Rad<T> i_psi)
        {
            p_phi = i_phi;
            p_theta = i_theta;
            p_psi = i_psi;
        }
    }

    public static class Rad3
    {
        extension<T>(Rad3<T>)
            where T : unmanaged, IFloatingPointIeee754<T>
        {
            #region Constructor methods.

            public static Rad3<T> FromDegrees(Deg3<T> i_degrees)
            {
                Rad<T> phi = Rad<T>.DegreesToRadians(i_degrees.p_phi);
                Rad<T> theta = Rad<T>.DegreesToRadians(i_degrees.p_theta);
                Rad<T> psi = Rad<T>.DegreesToRadians(i_degrees.p_psi);
                return new Rad3<T>(phi, theta, psi);
            }

            /// <summary>
            /// This function takes a rotation matrix, and return a (phi, thera, psi) trio of Euler angles,
            /// accordingly to the following sequence:
            /// First rotation: angle psi around x axis.
            /// Second rotation: angle theta around y axis.
            /// Third rotation: angle phi around z axis.
            /// </summary>
            /// <param name="i_mat"></param>
            /// <returns></returns>
            public static Rad3<T> CreateXYZSequenceFromRotationMatrix(Mat3x3<T> i_mat)
            {
                Rad<T> phi, theta, psi;

                phi = Rad<T>.Atan(-i_mat.p_row0.p_y / i_mat.p_row0.p_x);
                theta = Rad<T>.Asin(i_mat.p_row0.p_z);
                psi = Rad<T>.Atan(-i_mat.p_row1.p_z / i_mat.p_row2.p_z);

                return new Rad3<T>(phi, theta, psi);
            }

            /// <summary>
            /// This function takes a rotation matrix, and return a (phi, thera, psi) trio of Euler angles,
            /// accordingly to the following sequence:
            /// First rotation: angle psi around z axis.
            /// Second rotation: angle theta around y axis.
            /// Third rotation: angle phi around x axis.
            /// </summary>
            /// <param name="i_mat"></param>
            /// <returns></returns>
            public static Rad3<T> CreateZYXSequenceFromRotationMatrix(Mat3x3<T> i_mat)
            {
                Rad<T> phi, theta, psi;

                phi = Rad<T>.Atan(i_mat.p_row2.p_y / i_mat.p_row2.p_z);
                theta = Rad<T>.Asin(-i_mat.p_row2.p_x);
                psi = Rad<T>.Atan(i_mat.p_row1.p_x / i_mat.p_row0.p_x);

                return new Rad3<T>(phi, theta, psi);
            }

            /// <summary>
            /// This function takes a rotation matrix, and return a (phi, thera, psi) trio of Euler angles,
            /// accordingly to the following sequence:
            /// First rotation: angle psi around y axis.
            /// Second rotation: angle theta around z axis.
            /// Third rotation: angle phi around x axis.
            /// </summary>
            /// <param name="i_mat"></param>
            /// <returns></returns>
            public static Rad3<T> CreateYZXSequenceFromRotationMatrix(Mat3x3<T> i_mat)
            {
                Rad<T> phi, theta, psi;

                phi = Rad<T>.Atan(-i_mat.p_row1.p_z / i_mat.p_row1.p_y);
                theta = Rad<T>.Asin(i_mat.p_row1.p_x);
                psi = Rad<T>.Atan(-i_mat.p_row2.p_x / i_mat.p_row0.p_x);

                return new Rad3<T>(phi, theta, psi);
            }

            /// <summary>
            /// This function takes a rotation matrix, and return a (phi, thera, psi) trio of Euler angles,
            /// accordingly to the following sequence:
            /// First rotation: angle psi around x axis.
            /// Second rotation: angle theta around z axis.
            /// Third rotation: angle phi around y axis.
            /// </summary>
            /// <param name="i_mat"></param>
            /// <returns></returns>
            public static Rad3<T> CreateXZYSequenceFromRotationMatrix(Mat3x3<T> i_mat)
            {
                Rad<T> phi, theta, psi;

                phi = Rad<T>.Atan(i_mat.p_row0.p_z / i_mat.p_row0.p_x);
                theta = Rad<T>.Asin(-i_mat.p_row0.p_y);
                psi = Rad<T>.Atan(i_mat.p_row2.p_y / i_mat.p_row1.p_y);

                return new Rad3<T>(phi, theta, psi);
            }

            /// <summary>
            /// This function takes a rotation matrix, and return a (phi, thera, psi) trio of Euler angles,
            /// accordingly to the following sequence:
            /// First rotation: angle psi around y axis.
            /// Second rotation: angle theta around x axis.
            /// Third rotation: angle phi around z axis.
            /// </summary>
            /// <param name="i_mat"></param>
            /// <returns></returns>
            public static Rad3<T> CreateYXZSequenceFromRotationMatrix(Mat3x3<T> i_mat)
            {
                Rad<T> phi, theta, psi;

                phi = Rad<T>.Atan(i_mat.p_row1.p_x / i_mat.p_row1.p_y);
                theta = Rad<T>.Asin(-i_mat.p_row1.p_z);
                psi = Rad<T>.Atan(i_mat.p_row0.p_z / i_mat.p_row2.p_z);

                return new Rad3<T>(phi, theta, psi);
            }

            /// <summary>
            /// This function takes a rotation matrix, and return a (phi, thera, psi) trio of Euler angles,
            /// accordingly to the following sequence:
            /// First rotation: angle psi around z axis.
            /// Second rotation: angle theta around x axis.
            /// Third rotation: angle phi around y axis.
            /// </summary>
            /// <param name="i_mat"></param>
            /// <returns></returns>
            public static Rad3<T> CreateZXYSequenceFromRotationMatrix(Mat3x3<T> i_mat)
            {
                Rad<T> phi, theta, psi;

                phi = Rad<T>.Atan(-i_mat.p_row2.p_x / i_mat.p_row2.p_z);
                theta = Rad<T>.Asin(i_mat.p_row2.p_y);
                psi = Rad<T>.Atan(-i_mat.p_row0.p_y / i_mat.p_row1.p_y);

                return new Rad3<T>(phi, theta, psi);
            }

            /// <summary>
            /// This function takes a rotation matrix, and return a (phi, thera, psi) trio of Euler angles,
            /// accordingly to the following sequence:
            /// First rotation: angle psi around x axis.
            /// Second rotation: angle theta around y axis.
            /// Third rotation: angle phi around x axis.
            /// </summary>
            /// <param name="i_mat"></param>
            /// <returns></returns>
            public static Rad3<T> CreateXYXSequenceFromRotationMatrix(Mat3x3<T> i_mat)
            {
                Rad<T> phi, theta, psi;

                phi = Rad<T>.Atan(i_mat.p_row0.p_y / i_mat.p_row0.p_z);
                theta = Rad<T>.Asin(i_mat.p_row0.p_x);
                psi = Rad<T>.Atan(i_mat.p_row1.p_x / -i_mat.p_row2.p_x);

                return new Rad3<T>(phi, theta, psi);
            }

            /// <summary>
            /// This function takes a rotation matrix, and return a (phi, thera, psi) trio of Euler angles,
            /// accordingly to the following sequence:
            /// First rotation: angle psi around x axis.
            /// Second rotation: angle theta around z axis.
            /// Third rotation: angle phi around x axis.
            /// </summary>
            /// <param name="i_mat"></param>
            /// <returns></returns>
            public static Rad3<T> CreateXZXSequenceFromRotationMatrix(Mat3x3<T> i_mat)
            {
                Rad<T> phi, theta, psi;

                phi = Rad<T>.Atan(i_mat.p_row0.p_z / -i_mat.p_row0.p_y);
                theta = Rad<T>.Acos(i_mat.p_row0.p_x);
                psi = Rad<T>.Atan(i_mat.p_row2.p_x / i_mat.p_row1.p_x);

                return new Rad3<T>(phi, theta, psi);
            }

            /// <summary>
            /// This function takes a rotation matrix, and return a (phi, thera, psi) trio of Euler angles,
            /// accordingly to the following sequence:
            /// First rotation: angle psi around y axis.
            /// Second rotation: angle theta around z axis.
            /// Third rotation: angle phi around y axis.
            /// </summary>
            /// <param name="i_mat"></param>
            /// <returns></returns>
            public static Rad3<T> CreateYZYSequenceFromRotationMatrix(Mat3x3<T> i_mat)
            {
                Rad<T> phi, theta, psi;

                phi = Rad<T>.Atan(i_mat.p_row1.p_z / i_mat.p_row1.p_x);
                theta = Rad<T>.Acos(i_mat.p_row1.p_y);
                psi = Rad<T>.Atan(i_mat.p_row2.p_y / -i_mat.p_row0.p_y);

                return new Rad3<T>(phi, theta, psi);
            }

            /// <summary>
            /// This function takes a rotation matrix, and return a (phi, thera, psi) trio of Euler angles,
            /// accordingly to the following sequence:
            /// First rotation: angle psi around y axis.
            /// Second rotation: angle theta around x axis.
            /// Third rotation: angle phi around y axis.
            /// </summary>
            /// <param name="i_mat"></param>
            /// <returns></returns>
            public static Rad3<T> CreateYXYSequenceFromRotationMatrix(Mat3x3<T> i_mat)
            {
                Rad<T> phi, theta, psi;

                phi = Rad<T>.Atan(i_mat.p_row1.p_x / -i_mat.p_row1.p_z);
                theta = Rad<T>.Acos(i_mat.p_row1.p_y);
                psi = Rad<T>.Atan(i_mat.p_row0.p_y / i_mat.p_row2.p_y);

                return new Rad3<T>(phi, theta, psi);
            }

            /// <summary>
            /// This function takes a rotation matrix, and return a (phi, thera, psi) trio of Euler angles,
            /// accordingly to the following sequence:
            /// First rotation: angle psi around z axis.
            /// Second rotation: angle theta around x axis.
            /// Third rotation: angle phi around z axis.
            /// </summary>
            /// <param name="i_mat"></param>
            /// <returns></returns>
            public static Rad3<T> CreateZXZSequenceFromRotationMatrix(Mat3x3<T> i_mat)
            {
                Rad<T> phi, theta, psi;

                phi = Rad<T>.Atan(i_mat.p_row2.p_x / i_mat.p_row2.p_y);
                theta = Rad<T>.Acos(i_mat.p_row2.p_z);
                psi = Rad<T>.Atan(i_mat.p_row0.p_z / -i_mat.p_row1.p_z);

                return new Rad3<T>(phi, theta, psi);
            }

            /// <summary>
            /// This function takes a rotation matrix, and return a (phi, thera, psi) trio of Euler angles,
            /// accordingly to the following sequence:
            /// First rotation: angle psi around z axis.
            /// Second rotation: angle theta around y axis.
            /// Third rotation: angle phi around z axis.
            /// </summary>
            /// <param name="i_mat"></param>
            /// <returns></returns>
            public static Rad3<T> CreateZYZSequenceFromRotationMatrix(Mat3x3<T> i_mat)
            {
                Rad<T> phi, theta, psi;

                phi = Rad<T>.Atan(i_mat.p_row2.p_y / -i_mat.p_row2.p_x);
                theta = Rad<T>.Acos(i_mat.p_row2.p_z);
                psi = Rad<T>.Atan(i_mat.p_row1.p_z / i_mat.p_row0.p_z);

                return new Rad3<T>(phi, theta, psi);
            }

            /// <summary>
            /// This function takes a quaternion and returns the associated Euler angles (phi, theta, psi)
            /// according to the ZYX sequence.
            /// First rotation: angle psi through z axis.
            /// Second rotarion: angle theta through y axis.
            /// Third rotation: angle phi through x axis.
            /// </summary>
            /// <param name="i_quat">Input quaternion</param>
            /// <returns>Euler angles sequence</returns>
            public static Rad3<T> CreateZYXSequenceFromQuaternion(Quat<T> i_quat)
            {
                Rad3<T> eulerAngles = new();

                T two = Math<T>.Two;

                eulerAngles.p_phi = Rad<T>.Atan((two * (i_quat.p_y * i_quat.p_z + i_quat.p_x * i_quat.p_w)) /
                                    (T.One - two * (i_quat.p_x * i_quat.p_x + i_quat.p_y * i_quat.p_y)));

                eulerAngles.p_theta = Rad<T>.Asin(-two * (i_quat.p_x * i_quat.p_z - i_quat.p_y * i_quat.p_w));

                eulerAngles.p_psi = Rad<T>.Atan((two * (i_quat.p_x * i_quat.p_y + i_quat.p_z * i_quat.p_w)) /
                                    (T.One - two * (i_quat.p_y * i_quat.p_y + i_quat.p_z * i_quat.p_z)));
                return eulerAngles;
            }

            /// <summary>
            /// This function takes a quaternion and returns the associated Euler angles (phi, theta, psi)
            /// according to the XYZ sequence.
            /// First rotation: angle psi through x axis.
            /// Second rotarion: angle theta through y axis.
            /// Third rotation: angle phi through z axis.
            /// </summary>
            /// <param name="i_quat">Input quaternion</param>
            /// <returns>Euler angles sequence</returns>
            public static Rad3<T> CreaterXYZSequenceFromQuaternion(Quat<T> i_quat)
            {
                Rad3<T> eulerAngles = new();

                T two = Math<T>.Two;

                eulerAngles.p_phi = Rad<T>.Atan(-two * (i_quat.p_x * i_quat.p_y - i_quat.p_z * i_quat.p_w) /
                                        (T.One - two * (i_quat.p_y * i_quat.p_y + i_quat.p_z * i_quat.p_z)));

                eulerAngles.p_theta = Rad<T>.Asin(two * (i_quat.p_x * i_quat.p_z + i_quat.p_y * i_quat.p_w));

                eulerAngles.p_psi = Rad<T>.Atan(-two * (i_quat.p_y * i_quat.p_z - i_quat.p_x * i_quat.p_w) /
                                    (T.One - two * (i_quat.p_x * i_quat.p_x + i_quat.p_y * i_quat.p_y)));
                return eulerAngles;
            }

            /// <summary>
            /// This function takes a quaternion and returns the associated Euler angles (phi, theta, psi)
            /// according to the YZX sequence.
            /// First rotation: angle psi through y axis.
            /// Second rotarion: angle theta through z axis.
            /// Third rotation: angle phi through x axis.
            /// </summary>
            /// <param name="i_quat">Input quaternion</param>
            /// <returns>Euler angles sequence</returns>
            public static Rad3<T> CreateYZXSequenceFromQuaternion(Quat<T> i_quat)
            {
                Rad3<T> eulerAngles = new();

                T two = Math<T>.Two;

                eulerAngles.p_phi = Rad<T>.Atan(-two * (i_quat.p_y * i_quat.p_z - i_quat.p_x * i_quat.p_w) /
                                    (T.One - two * (i_quat.p_x * i_quat.p_x + i_quat.p_z * i_quat.p_z)));

                eulerAngles.p_theta = Rad<T>.Asin(two * (i_quat.p_x * i_quat.p_y + i_quat.p_z * i_quat.p_w));

                eulerAngles.p_psi = Rad<T>.Atan(-two * (i_quat.p_x * i_quat.p_z - i_quat.p_y * i_quat.p_w) /
                                    (T.One - two * (i_quat.p_y * i_quat.p_y + i_quat.p_z * i_quat.p_z)));
                return eulerAngles;
            }

            /// <summary>
            /// This function takes a quaternion and returns the associated Euler angles (phi, theta, psi)
            /// according to the XYX sequence.
            /// First rotation: angle psi through x axis.
            /// Second rotarion: angle theta through y axis.
            /// Third rotation: angle phi through x axis.
            /// </summary>
            /// <param name="i_quat">Input quaternion</param>
            /// <returns>Euler angles sequence</returns>
            public static Rad3<T> CreateXYXSequenceFromQuaternion(Quat<T> i_quat)
            {
                Rad3<T> eulerAngles = new();

                T two = Math<T>.Two;

                eulerAngles.p_phi = Rad<T>.Atan((i_quat.p_x * i_quat.p_y - i_quat.p_z * i_quat.p_w) /
                                        ((i_quat.p_x * i_quat.p_z + i_quat.p_y * i_quat.p_w)));

                eulerAngles.p_theta = Rad<T>.Acos(T.One - two * (i_quat.p_y * i_quat.p_y + i_quat.p_z * i_quat.p_z));

                eulerAngles.p_psi = Rad<T>.Atan((i_quat.p_x * i_quat.p_y + i_quat.p_z * i_quat.p_w)) /
                                        ((-i_quat.p_x * i_quat.p_z + i_quat.p_y * i_quat.p_w));
                return eulerAngles;
            }

            /// <summary>
            /// This function takes a quaternion and returns the associated Euler angles (phi, theta, psi)
            /// according to the XZX sequence.
            /// First rotation: angle psi through x axis.
            /// Second rotarion: angle theta through z axis.
            /// Third rotation: angle phi through x axis.
            /// </summary>
            /// <param name="i_quat">Input quaternion</param>
            /// <returns>Euler angles sequence</returns>
            public static Rad3<T> CreateXZXSequenceFromQuaternion(Quat<T> i_quat)
            {
                Rad3<T> eulerAngles = new();

                T two = Math<T>.Two;

                eulerAngles.p_phi = Rad<T>.Atan((i_quat.p_x * i_quat.p_z + i_quat.p_y * i_quat.p_w) /
                                        ((-i_quat.p_x * i_quat.p_y + i_quat.p_z * i_quat.p_w)));

                eulerAngles.p_theta = Rad<T>.Acos(T.One - two * (i_quat.p_y * i_quat.p_y + i_quat.p_z * i_quat.p_z));

                eulerAngles.p_psi = Rad<T>.Atan((i_quat.p_x * i_quat.p_z - i_quat.p_y * i_quat.p_w) /
                                        (i_quat.p_x * i_quat.p_y + i_quat.p_z * i_quat.p_w));
                return eulerAngles;
            }

            /// <summary>
            /// This function takes a quaternion and returns the associated Euler angles (phi, theta, psi)
            /// according to the XZY sequence.
            /// First rotation: angle psi through x axis.
            /// Second rotarion: angle theta through z axis.
            /// Third rotation: angle phi through y axis.
            /// </summary>
            /// <param name="i_quat">Input quaternion</param>
            /// <returns>Euler angles sequence</returns>
            public static Rad3<T> CreateXZYSequenceFromQuaternion(Quat<T> i_quat)
            {
                Rad3<T> eulerAngles = new();

                T two = Math<T>.Two;

                eulerAngles.p_phi = Rad<T>.Atan(two * (i_quat.p_x * i_quat.p_z + i_quat.p_y * i_quat.p_w) /
                                        (T.One - two * (i_quat.p_y * i_quat.p_y + i_quat.p_z * i_quat.p_z)));

                eulerAngles.p_theta = Rad<T>.Asin(-two * (i_quat.p_x * i_quat.p_y - i_quat.p_z * i_quat.p_w));

                eulerAngles.p_psi = Rad<T>.Atan(two * (i_quat.p_y * i_quat.p_z + i_quat.p_x * i_quat.p_w) /
                                        (T.One - two * (i_quat.p_x * i_quat.p_x + i_quat.p_z * i_quat.p_z)));
                return eulerAngles;
            }

            /// <summary>
            /// This function takes a quaternion and returns the associated Euler angles (phi, theta, psi)
            /// according to the YXZ sequence.
            /// First rotation: angle psi through y axis.
            /// Second rotarion: angle theta through x axis.
            /// Third rotation: angle phi through z axis.
            /// </summary>
            /// <param name="i_quat">Input quaternion</param>
            /// <returns>Euler angles sequence</returns>
            public static Rad3<T> CreateYXZSequenceFromQuaternion(Quat<T> i_quat)
            {
                Rad3<T> eulerAngles = new();

                T two = Math<T>.Two;

                eulerAngles.p_phi = Rad<T>.Atan(two * (i_quat.p_x * i_quat.p_y + i_quat.p_z * i_quat.p_w) /
                                        (T.One - two * (i_quat.p_x * i_quat.p_x + i_quat.p_z * i_quat.p_z)));

                eulerAngles.p_theta = Rad<T>.Asin(-two * (i_quat.p_y * i_quat.p_z - i_quat.p_x * i_quat.p_w));

                eulerAngles.p_psi = Rad<T>.Atan(two * (i_quat.p_x * i_quat.p_z + i_quat.p_y * i_quat.p_w) /
                                        (T.One - two * (i_quat.p_x * i_quat.p_x + i_quat.p_y * i_quat.p_y)));
                return eulerAngles;
            }

            /// <summary>
            /// This function takes a quaternion and returns the associated Euler angles (phi, theta, psi)
            /// according to the YZY sequence.
            /// First rotation: angle psi through y axis.
            /// Second rotarion: angle theta through z axis.
            /// Third rotation: angle phi through y axis.
            /// </summary>
            /// <param name="i_quat">Input quaternion</param>
            /// <returns>Euler angles sequence</returns>
            public static Rad3<T> CreateYZYSequenceFromQuaternion(Quat<T> i_quat)
            {
                Rad3<T> eulerAngles = new();

                T two = Math<T>.Two;

                eulerAngles.p_phi = Rad<T>.Atan((i_quat.p_y * i_quat.p_z - i_quat.p_x * i_quat.p_w) /
                                        ((i_quat.p_x * i_quat.p_y + i_quat.p_z * i_quat.p_w)));

                eulerAngles.p_theta = Rad<T>.Acos(T.One - two * (i_quat.p_x * i_quat.p_x + i_quat.p_z * i_quat.p_z));

                eulerAngles.p_psi = Rad<T>.Atan((i_quat.p_y * i_quat.p_z + i_quat.p_x * i_quat.p_w) /
                                        ((-i_quat.p_x * i_quat.p_y + i_quat.p_z * i_quat.p_w)));
                return eulerAngles;
            }

            /// <summary>
            /// This function takes a quaternion and returns the associated Euler angles (phi, theta, psi)
            /// according to the YXY sequence.
            /// First rotation: angle psi through y axis.
            /// Second rotarion: angle theta through x axis.
            /// Third rotation: angle phi through y axis.
            /// </summary>
            /// <param name="i_quat">Input quaternion</param>
            /// <returns>Euler angles sequence</returns>
            public static Rad3<T> CreateYXYSequenceFromQuaternion(Quat<T> i_quat)
            {
                Rad3<T> eulerAngles = new();

                T two = Math<T>.Two;

                eulerAngles.p_phi = Rad<T>.Atan((i_quat.p_x * i_quat.p_y + i_quat.p_z * i_quat.p_w) /
                                        (-i_quat.p_y * i_quat.p_z + i_quat.p_x * i_quat.p_w));

                eulerAngles.p_theta = Rad<T>.Acos(T.One - two * (i_quat.p_x * i_quat.p_x + i_quat.p_z * i_quat.p_z));

                eulerAngles.p_psi = Rad<T>.Atan((i_quat.p_x * i_quat.p_y - i_quat.p_z * i_quat.p_w) /
                                        (i_quat.p_y * i_quat.p_z + i_quat.p_x * i_quat.p_w));
                return eulerAngles;
            }

            /// <summary>
            /// This function takes a quaternion and returns the associated Euler angles (phi, theta, psi)
            /// according to the ZXY sequence.
            /// First rotation: angle psi through z axis.
            /// Second rotarion: angle theta through x axis.
            /// Third rotation: angle phi through y axis.
            /// </summary>
            /// <param name="i_quat">Input quaternion</param>
            /// <returns>Euler angles sequence</returns>
            public static Rad3<T> CreateZXYSequenceFromQuaternion(Quat<T> i_quat)
            {
                Mat3x3<T> rotMatrix = Mat3x3<T>.CreateRotationMatrixFromQuaternion(i_quat);
                Rad3<T> eulerAngles = CreateZXYSequenceFromRotationMatrix(rotMatrix);
                return eulerAngles;
            }

            /// <summary>
            /// This function takes a quaternion and returns the associated Euler angles (phi, theta, psi)
            /// according to the ZXZ sequence.
            /// First rotation: angle psi through z axis.
            /// Second rotarion: angle theta through x axis.
            /// Third rotation: angle phi through z axis.
            /// </summary>
            /// <param name="i_quat">Input quaternion</param>
            /// <returns>Euler angles sequence</returns>
            public static Rad3<T> CreateZXZSequenceFromQuaternion(Quat<T> i_quat)
            {
                Rad3<T> eulerAngles = new();

                T two = Math<T>.Two;

                eulerAngles.p_phi = Rad<T>.Atan((i_quat.p_x * i_quat.p_z - i_quat.p_y * i_quat.p_w) /
                                        (i_quat.p_y * i_quat.p_z + i_quat.p_x * i_quat.p_w));

                eulerAngles.p_theta = Rad<T>.Acos(T.One - two * (i_quat.p_x * i_quat.p_x + i_quat.p_y * i_quat.p_y));

                eulerAngles.p_psi = Rad<T>.Atan((i_quat.p_x * i_quat.p_z + i_quat.p_y * i_quat.p_w) /
                                        (-i_quat.p_y * i_quat.p_z + i_quat.p_x * i_quat.p_w));
                return eulerAngles;
            }

            /// <summary>
            /// This function takes a quaternion and returns the associated Euler angles (phi, theta, psi)
            /// according to the ZYZ sequence.
            /// First rotation: angle psi through z axis.
            /// Second rotarion: angle theta through y axis.
            /// Third rotation: angle phi through z axis.
            /// </summary>
            /// <param name="i_quat">Input quaternion</param>
            /// <returns>Euler angles sequence</returns>
            public static Rad3<T> CreateZYZSequenceFromQuaternion(Quat<T> i_quat)
            {
                Rad3<T> eulerAngles = new();

                T two = Math<T>.Two;

                eulerAngles.p_phi = Rad<T>.Atan((i_quat.p_y * i_quat.p_z + i_quat.p_x * i_quat.p_w) /
                                        (-i_quat.p_x * i_quat.p_z + i_quat.p_y * i_quat.p_w));

                eulerAngles.p_theta = Rad<T>.Acos(T.One - two * (i_quat.p_x * i_quat.p_x + i_quat.p_y * i_quat.p_y));

                eulerAngles.p_psi = Rad<T>.Atan((i_quat.p_y * i_quat.p_z - i_quat.p_x * i_quat.p_w) /
                                        (i_quat.p_x * i_quat.p_z + i_quat.p_y * i_quat.p_w));
                return eulerAngles;
            }

            #endregion
        }
    }
}
