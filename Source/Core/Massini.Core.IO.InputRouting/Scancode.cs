
namespace Massini.Core.IO.InputRouting
{
    /// <summary>
    /// Stores the scancode of a key.
    /// </summary>
    /// <param name="i_scancode"></param>
    public readonly struct Scancode(int i_scancode)
    {
        public static implicit operator Scancode(int i_scancode)
            => new Scancode(i_scancode);

        public static explicit operator int(Scancode i_scancode)
            => i_scancode.m_scancode;

        public override string ToString()
        {
            return m_scancode.ToString();
        }

        private readonly int m_scancode = i_scancode;
    }
}
