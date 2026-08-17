using System.Numerics;
using System.Runtime.InteropServices;

namespace Massini.Graphics.Color
{
    /// <summary>
    /// RGBA color struct.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Rgba<T>
        where T : unmanaged, INumber<T>
    {
        public T p_r;
        public T p_g;
        public T p_b;
        public T p_a;

        public Rgba(T i_r, T i_g, T i_b, T i_a)
        {
            p_r = i_r;
            p_g = i_g;
            p_b = i_b;
            p_a = i_a;
        }

        public T this[Index i_index]
        {
            readonly get
            {
                int index = i_index.GetOffset(4);
                return index switch
                {
                    0 => p_r,
                    1 => p_g,
                    2 => p_b,
                    3 => p_a,
                    _ => throw new IndexOutOfRangeException()
                };
            }
            set
            {
                int index = i_index.GetOffset(4);
                switch (index)
                {
                    case 0: p_r = value; break;
                    case 1: p_g = value; break;
                    case 2: p_b = value; break;
                    case 3: p_a = value; break;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }

        public override string ToString()
        {
            return $"R: {p_r}, G: {p_g}, B: {p_b}, A: {p_a}";
        }
    }
}
