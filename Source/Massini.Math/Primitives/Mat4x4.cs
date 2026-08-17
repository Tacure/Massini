
using System.Numerics;
using System.Runtime.InteropServices;
using Massini.Math.Primitives;

namespace Massini.Math.Primitives
{
    [StructLayout(LayoutKind.Sequential)]
    public partial struct Mat4x4<T>
        where T : unmanaged, IFloatingPointIeee754<T>
    {
        public Vec4<T> p_row0;
        public Vec4<T> p_row1;
        public Vec4<T> p_row2;
        public Vec4<T> p_row3;

        public Mat4x4() { }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="i_other"></param>
        public Mat4x4(Mat4x4<T> i_other)
        {
            p_row0 = i_other.p_row0;
            p_row1 = i_other.p_row1;
            p_row2 = i_other.p_row2;
            p_row3 = i_other.p_row3;
        }

        public Mat4x4(Mat3x3<T> i_other)
        {
            p_row0 = new(i_other.p_row0, T.Zero);
            p_row1 = new(i_other.p_row1, T.Zero);
            p_row2 = new(i_other.p_row2, T.Zero);
            p_row3 = Vec4<T>.UnitW;
        }

        public Mat4x4(Vec4<T> i_row0, Vec4<T> i_row1, Vec4<T> i_row2, Vec4<T> i_row3)
        {
            p_row0 = i_row0;
            p_row1 = i_row1;
            p_row2 = i_row2;
            p_row3 = i_row3;
        }

        public static implicit operator Mat4x4<T>((Vec4<T> Row0, Vec4<T> Row1, Vec4<T> Row2, Vec4<T> Row3) i_other)
            => new(i_other.Row0, i_other.Row1, i_other.Row2, i_other.Row3);

        public static bool operator ==(Mat4x4<T> i_mat1, Mat4x4<T> i_mat2)
            => i_mat1.p_row0 == i_mat2.p_row0 && i_mat1.p_row1 == i_mat2.p_row1 && i_mat1.p_row2 == i_mat2.p_row2 && i_mat1.p_row3 == i_mat2.p_row3;

        public static bool operator !=(Mat4x4<T> i_mat1, Mat4x4<T> i_mat2)
            => i_mat1.p_row0 != i_mat2.p_row0 && i_mat1.p_row1 != i_mat2.p_row1 && i_mat1.p_row2 != i_mat2.p_row2 && i_mat1.p_row3 != i_mat2.p_row3;

        public static Mat4x4<T> operator *(Mat4x4<T> i_mat1, Mat4x4<T> i_mat2)
            => new()
            {
                p_row0 = i_mat1.p_row0.p_x * i_mat2.p_row0 + i_mat1.p_row0.p_y * i_mat2.p_row1 + i_mat1.p_row0.p_z * i_mat2.p_row2 + i_mat1.p_row0.p_w * i_mat2.p_row3,
                p_row1 = i_mat1.p_row1.p_x * i_mat2.p_row0 + i_mat1.p_row1.p_y * i_mat2.p_row1 + i_mat1.p_row1.p_z * i_mat2.p_row2 + i_mat1.p_row1.p_w * i_mat2.p_row3,
                p_row2 = i_mat1.p_row2.p_x * i_mat2.p_row0 + i_mat1.p_row2.p_y * i_mat2.p_row1 + i_mat1.p_row2.p_z * i_mat2.p_row2 + i_mat1.p_row2.p_w * i_mat2.p_row3,
                p_row3 = i_mat1.p_row3.p_x * i_mat2.p_row0 + i_mat1.p_row3.p_y * i_mat2.p_row1 + i_mat1.p_row3.p_z * i_mat2.p_row2 + i_mat1.p_row3.p_w * i_mat2.p_row3,
            };

        public static Vec4<T> operator *(Mat4x4<T> i_mat, Vec4<T> i_vec)
            => new()
            {
                p_x = i_vec.p_x * i_mat.p_row0.p_x + i_vec.p_y * i_mat.p_row0.p_y + i_vec.p_z * i_mat.p_row0.p_z + i_vec.p_w * i_mat.p_row0.p_w,
                p_y = i_vec.p_x * i_mat.p_row1.p_x + i_vec.p_y * i_mat.p_row1.p_y + i_vec.p_z * i_mat.p_row1.p_z + i_vec.p_w * i_mat.p_row1.p_w,
                p_z = i_vec.p_x * i_mat.p_row2.p_x + i_vec.p_y * i_mat.p_row2.p_y + i_vec.p_z * i_mat.p_row2.p_z + i_vec.p_w * i_mat.p_row2.p_w,
                p_w = i_vec.p_x * i_mat.p_row3.p_x + i_vec.p_y * i_mat.p_row3.p_y + i_vec.p_z * i_mat.p_row3.p_z + i_vec.p_w * i_mat.p_row3.p_w,
            };

        public T this[Index i_idx, Index i_idy]
        {
            readonly get
            {
                int idx = i_idx.GetOffset(Width);
                int idy = i_idy.GetOffset(Height);
                return idy switch
                {
                    0 => p_row0[idx],
                    1 => p_row1[idx],
                    2 => p_row2[idx],
                    3 => p_row3[idx],
                    _ => throw new IndexOutOfRangeException(),
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
                    case 3: p_row3[idx] = value; break;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }

        public static Mat4x4<T> Zero
            => new(Vec4<T>.Zero, Vec4<T>.Zero, Vec4<T>.Zero, Vec4<T>.Zero);

        public static Mat4x4<T> Identity
            => new(Vec4<T>.UnitX, Vec4<T>.UnitY, Vec4<T>.UnitZ, Vec4<T>.UnitW);

        public Vec4<T> Row0 { readonly get => p_row0; set => p_row0 = value; }

        public Vec4<T> Row1 { readonly get => p_row1; set => p_row1 = value; }

        public Vec4<T> Row2 { readonly get => p_row2; set => p_row2 = value; }

        public Vec4<T> Row3 { readonly get => p_row3; set => p_row3 = value; }

        public readonly int Width => 4;

        public readonly int Height => 4;

        public override readonly string ToString()
        {
            return $"[R0: {p_row0} R1: {p_row1} R2: {p_row2} R3: {p_row3}]";
        }

        public override readonly bool Equals(object? i_obj)
        {
            if (i_obj is Mat4x4<T> vec)
            {
                return this == vec;
            }
            else
            {
                return false;
            }
        }

        public override readonly int GetHashCode()
        {
            return p_row0.GetHashCode() ^ p_row1.GetHashCode() ^ p_row2.GetHashCode() ^ p_row3.GetHashCode();
        }

        public readonly bool Equals(Mat4x4<T> other)
        {
            return this == other;
        }
    }

    public static class Mat4x4
    {
        extension<T>(Mat4x4<T>)
            where T : unmanaged, IFloatingPointIeee754<T>
        {
            #region Constructor methods.

            /// <summary>
            /// This function returns a 4x4 translation matrix.
            /// </summary>
            /// <param name="i_x">Translation along X axis.</param>
            /// <param name="i_y">Translation along Y axis.</param>
            /// <param name="i_z">Translation along Z axis.</param>
            /// <returns>A translation matrix.</returns>
            public static Mat4x4<T> CreateTranslationMatrix(T i_x, T i_y, T i_z)
            {
                // Row-major
                return new Mat4x4<T>(
                    new Vec4<T>(T.One, T.Zero, T.Zero, i_x),
                    new Vec4<T>(T.Zero, T.One, T.Zero, i_y),
                    new Vec4<T>(T.Zero, T.Zero, T.One, i_z),
                    new Vec4<T>(T.Zero, T.Zero, T.Zero, T.One)
                );
            }

            /// <summary>
            /// This function returns a 4x4 scaling matrix.
            /// </summary>
            /// <param name="i_x">Scale factor along X axis.</param>
            /// <param name="i_y">Scale factor along Y axis.</param>
            /// <param name="i_z">Scale factor along Z axis.</param>
            /// <returns>A scaling matrix.</returns>
            public static Mat4x4<T> CreateScaleMatrix(T i_x, T i_y, T i_z)
            {
                // Row-major
                return new Mat4x4<T>(
                    new Vec4<T>(i_x, T.Zero, T.Zero, T.Zero),
                    new Vec4<T>(T.Zero, i_y, T.Zero, T.Zero),
                    new Vec4<T>(T.Zero, T.Zero, i_z, T.Zero),
                    new Vec4<T>(T.Zero, T.Zero, T.Zero, T.One)
                );
            }

            /// <summary>
            /// This function returns a 4x4 skew (shear) matrix.
            /// </summary>
            /// <remarks>
            /// Skew transforms one axis in proportion to another.  
            /// For example, X by Y means X is displaced proportionally to Y.
            /// </remarks>
            /// <param name="i_xy">Skew of X relative to Y.</param>
            /// <param name="i_xz">Skew of X relative to Z.</param>
            /// <param name="i_yx">Skew of Y relative to X.</param>
            /// <param name="i_yz">Skew of Y relative to Z.</param>
            /// <param name="i_zx">Skew of Z relative to X.</param>
            /// <param name="i_zy">Skew of Z relative to Y.</param>
            /// <returns>A skew (shear) matrix.</returns>
            public static Mat4x4<T> CreateSkewMatrix(
                T i_xy, T i_xz,
                T i_yx, T i_yz,
                T i_zx, T i_zy)
            {
                // Row-major
                return new Mat4x4<T>(
                    new Vec4<T>(T.One, i_xy, i_xz, T.Zero),
                    new Vec4<T>(i_yx, T.One, i_yz, T.Zero),
                    new Vec4<T>(i_zx, i_zy, T.One, T.Zero),
                    new Vec4<T>(T.Zero, T.Zero, T.Zero, T.One)
                );
            }

            /// <summary>
            /// This function receives 3 vectors and returns a 4x4 view matrix.
            /// </summary>
            /// <param name="i_eye"></param>
            /// <param name="i_target"></param>
            /// <param name="i_up"></param>
            /// <returns></returns>
            public static Mat4x4<T> CreateLookAtMatrix(Vec3<T> i_eye, Vec3<T> i_target, Vec3<T> i_up)
            {
                Vec3<T> f = Vec3<T>.Normalize(i_eye - i_target);
                Vec3<T> s = Vec3<T>.Normalize(Vec3<T>.Cross(f, i_up));
                Vec3<T> u = Vec3<T>.Cross(s, f);

                // Row-major
                Mat4x4<T> view = new(
                    new Vec4<T>(s.p_x, s.p_y, s.p_z, -Vec3<T>.Dot(s, i_eye)),
                    new Vec4<T>(u.p_x, u.p_y, u.p_z, -Vec3<T>.Dot(u, i_eye)),
                    new Vec4<T>(-f.p_x, -f.p_y, -f.p_z, Vec3<T>.Dot(f, i_eye)),
                    new Vec4<T>(T.Zero, T.Zero, T.Zero, T.One)
                );

                return view;
            }

            /// <summary>
            /// Builds a 4x4 perspective projection matrix.
            /// </summary>
            /// <remarks>
            /// Uses Vulkan-style NDC coordinates: Z ∈ [0, 1], Y is up.
            /// </remarks>
            /// <param name="i_fovY">Vertical field of view, in radians.</param>
            /// <param name="i_aspect">Aspect ratio (width / height).</param>
            /// <param name="i_near">Near clipping plane distance.</param>
            /// <param name="i_far">Far clipping plane distance.</param>
            /// <returns>A 4x4 perspective projection matrix.</returns>
            public static Mat4x4<T> CreatePerspectiveMatrix(Rad<T> i_fovY, T i_aspect, T i_near, T i_far)
            {
                T f = T.One / Rad<T>.Tan(i_fovY / Math<T>.Two);

                Mat4x4<T> result = Mat4x4<T>.Identity;

                // Row-major
                result.p_row0 = new Vec4<T>(f / i_aspect, T.Zero, T.Zero, T.Zero);
                result.p_row1 = new Vec4<T>(T.Zero, f, T.Zero, T.Zero);
                result.p_row2 = new Vec4<T>(T.Zero, T.Zero, i_far / (i_far - i_near), (-i_far * i_near) / (i_far - i_near));
                result.p_row3 = new Vec4<T>(T.Zero, T.Zero, T.One, T.Zero);

                return result;
            }

            public static Mat4x4<T> CreatePerspectiveSkewMatrix(
                T i_left, T i_right,
                T i_bottom, T i_top,
                T i_near, T i_far)
            {
                T twoNear = Math<T>.Two * i_near;
                T width = i_right - i_left;
                T height = i_top - i_bottom;
                T depth = i_far - i_near;

                Mat4x4<T> result = default;

                result.p_row0 = new Vec4<T>(
                    twoNear / width,
                    T.Zero,
                    (i_right + i_left) / width,
                    T.Zero
                );

                result.p_row1 = new Vec4<T>(
                    T.Zero,
                    twoNear / height,
                    (i_top + i_bottom) / height,
                    T.Zero
                );

                result.p_row2 = new Vec4<T>(
                    T.Zero,
                    T.Zero,
                    i_far / depth,
                    (-i_far * i_near) / depth
                );

                result.p_row3 = new Vec4<T>(
                    T.Zero,
                    T.Zero,
                    T.One,
                    T.Zero
                );

                return result;
            }

            public static Mat4x4<T> CreatePerspectiveMatrixWithOffset(
                Rad<T> i_fovY,
                T i_aspect,
                T i_near,
                T i_far,
                T i_offsetX,
                T i_offsetY)
            {
                T tanHalfFovY = Rad<T>.Tan(i_fovY / Math<T>.Two);

                T top = i_near * tanHalfFovY;
                T bottom = -top;

                T right = top * i_aspect;
                T left = -right;

                left += i_offsetX;
                right += i_offsetX;
                bottom += i_offsetY;
                top += i_offsetY;

                return CreatePerspectiveSkewMatrix(
                    left, right,
                    bottom, top,
                    i_near, i_far
                );
            }

            /// <summary>
            /// Builds a 4x4 orthographic projection matrix.
            /// </summary>
            /// <remarks>
            /// Uses Vulkan-style NDC coordinates: Z ∈ [0, 1], Y is up.
            /// </remarks>
            /// <param name="i_left">Left clipping plane.</param>
            /// <param name="i_right">Right clipping plane.</param>
            /// <param name="i_bottom">Bottom clipping plane.</param>
            /// <param name="i_top">Top clipping plane.</param>
            /// <param name="i_near">Near clipping plane distance.</param>
            /// <param name="i_far">Far clipping plane distance.</param>
            /// <returns>A 4x4 orthographic projection matrix.</returns>
            public static Mat4x4<T> CreateOrthographicMatrix(
                T i_left,
                T i_right,
                T i_bottom,
                T i_top,
                T i_near,
                T i_far)
            {
                Mat4x4<T> result = Mat4x4<T>.Identity;

                T rl = i_right - i_left;
                T tb = i_top - i_bottom;
                T fn = i_far - i_near;

                T two = T.CreateChecked(2);

                // Row-major
                result.p_row0 = new Vec4<T>(two / rl, T.Zero, T.Zero, -(i_right + i_left) / rl);
                result.p_row1 = new Vec4<T>(T.Zero, two / tb, T.Zero, -(i_top + i_bottom) / tb);
                result.p_row2 = new Vec4<T>(T.Zero, T.Zero, T.One / (i_far - i_near), -i_near / fn);
                result.p_row3 = new Vec4<T>(T.Zero, T.Zero, T.Zero, T.One);

                return result;
            }

            /// <summary>
            /// Converts from Vulkan NDC to OpenGL NDC.
            /// </summary>
            /// <remarks>
            /// Vulkan: Z ∈ [0, 1], +Y up  
            /// OpenGL: Z ∈ [-1, 1], +Y up
            /// </remarks>
            public static Mat4x4<T> CreateVulkanToOpenGlNdcMatrix()
            {
                return new Mat4x4<T>(
                    new(T.One, T.Zero, T.Zero, T.Zero),
                    new(T.Zero, T.One, T.Zero, T.Zero),
                    new(T.Zero, T.Zero, T.CreateChecked(2), -T.One),
                    new(T.Zero, T.Zero, T.Zero, T.One)
                );
            }

            /// <summary>
            /// Converts from OpenGL NDC to Vulkan NDC.
            /// </summary>
            /// <remarks>
            /// OpenGL: Z ∈ [-1, 1], +Y up  
            /// Vulkan: Z ∈ [0, 1], +Y up
            /// </remarks>
            public static Mat4x4<T> CreateOpenGLToVulkanNdcMatrix()
            {
                return new Mat4x4<T>(
                    new(T.One, T.Zero, T.Zero, T.Zero),
                    new(T.Zero, T.One, T.Zero, T.Zero),
                    new(T.Zero, T.Zero, T.CreateChecked(0.5f), T.CreateChecked(0.5f)),
                    new(T.Zero, T.Zero, T.Zero, T.One)
                );
            }

            /// <summary>
            /// Converts from Vulkan NDC to Direct3D 12 NDC.
            /// </summary>
            /// <remarks>
            /// Vulkan: Z ∈ [0, 1], +Y up  
            /// D3D12:  Z ∈ [0, 1], -Y down
            /// </remarks>
            public static Mat4x4<T> CreateVulkanToD3d12NdcMatrix()
            {
                return new Mat4x4<T>(
                    new(T.One, T.Zero, T.Zero, T.Zero),
                    new(T.Zero, -T.One, T.Zero, T.Zero),
                    new(T.Zero, T.Zero, T.One, T.Zero),
                    new(T.Zero, T.Zero, T.Zero, T.One)
                );
            }

            /// <summary>
            /// Converts from Direct3D 12 NDC to Vulkan NDC.
            /// </summary>
            /// <remarks>
            /// D3D12:  Z ∈ [0, 1], -Y down  
            /// Vulkan: Z ∈ [0, 1], +Y up
            /// </remarks>
            public static Mat4x4<T> CreateD3d12ToVulkanNdcMatrix()
            {
                return new Mat4x4<T>(
                    new(T.One, T.Zero, T.Zero, T.Zero),
                    new(T.Zero, -T.One, T.Zero, T.Zero),
                    new(T.Zero, T.Zero, T.One, T.Zero),
                    new(T.Zero, T.Zero, T.Zero, T.One)
                );
            }

            /// <summary>
            /// Converts from Vulkan NDC to Metal NDC.
            /// </summary>
            /// <remarks>
            /// Vulkan: Z ∈ [0, 1], +Y up  
            /// Metal:  Z ∈ [0, 1], +Y down (like D3D12)
            /// </remarks>
            public static Mat4x4<T> CreateVulkanToMetalNdcMatrix()
            {
                return new Mat4x4<T>(
                    new(T.One, T.Zero, T.Zero, T.Zero),
                    new(T.Zero, -T.One, T.Zero, T.Zero),
                    new(T.Zero, T.Zero, T.One, T.Zero),
                    new(T.Zero, T.Zero, T.Zero, T.One)
                );
            }

            /// <summary>
            /// Converts from Metal NDC to Vulkan NDC.
            /// </summary>
            /// <remarks>
            /// Metal:  Z ∈ [0, 1], +Y down  
            /// Vulkan: Z ∈ [0, 1], +Y up
            /// </remarks>
            public static Mat4x4<T> CreateMetalToVulkanNdcMatrix()
            {
                return new Mat4x4<T>(
                    new(T.One, T.Zero, T.Zero, T.Zero),
                    new(T.Zero, -T.One, T.Zero, T.Zero),
                    new(T.Zero, T.Zero, T.One, T.Zero),
                    new(T.Zero, T.Zero, T.Zero, T.One)
                );
            }

            #endregion

            #region Basic methods.

            /// <summary>
            /// This function receives a 4x4 matrix and returns the matrix transpose.
            /// </summary>
            /// <param name="i_matrix"></param>
            /// <returns></returns>
            public static Mat4x4<T> Transpose(Mat4x4<T> i_matrix)
            {
                return new Mat4x4<T>()
                {
                    p_row0 = new(i_matrix.p_row0.p_x, i_matrix.p_row1.p_x, i_matrix.p_row2.p_x, i_matrix.p_row3.p_x),
                    p_row1 = new(i_matrix.p_row0.p_y, i_matrix.p_row1.p_y, i_matrix.p_row2.p_y, i_matrix.p_row3.p_y),
                    p_row2 = new(i_matrix.p_row0.p_z, i_matrix.p_row1.p_z, i_matrix.p_row2.p_z, i_matrix.p_row3.p_z),
                    p_row3 = new(i_matrix.p_row0.p_w, i_matrix.p_row1.p_w, i_matrix.p_row2.p_w, i_matrix.p_row3.p_w),
                };
            }

            #endregion
        }
    }
}
