namespace Massini.Core.IO.InputRouting
{
    public readonly struct MouseId(int i_id = -1) : IEquatable<MouseId>, IComparable<MouseId>, IComparable
    {
        public static implicit operator MouseId(int i_id) => new(i_id);
        public static explicit operator int(MouseId i_id) => i_id.m_id;

        public static bool operator ==(MouseId i_gamepadId1, MouseId i_gamepadId2)
            => i_gamepadId1.m_id == i_gamepadId2.m_id;

        public static bool operator !=(MouseId i_gamepadId1, MouseId i_gamepadId2)
            => i_gamepadId1.m_id != i_gamepadId2.m_id;

        public static bool operator <(MouseId i_gamepadId1, MouseId i_gamepadId2)
            => i_gamepadId1.m_id < i_gamepadId2.m_id;

        public static bool operator <=(MouseId i_gamepadId1, MouseId i_gamepadId2)
            => i_gamepadId1.m_id <= i_gamepadId2.m_id;

        public static bool operator >(MouseId i_gamepadId1, MouseId i_gamepadId2)
            => i_gamepadId1.m_id > i_gamepadId2.m_id;

        public static bool operator >=(MouseId i_gamepadId1, MouseId i_gamepadId2)
            => i_gamepadId1.m_id >= i_gamepadId2.m_id;

        public bool Equals(MouseId i_other)
        {
            return m_id == i_other.m_id;
        }

        public int CompareTo(MouseId i_other)
        {
            return m_id.CompareTo(i_other.m_id);
        }

        public override bool Equals(object? i_obj)
        {
            return i_obj is MouseId other && Equals(other);
        }

        public int CompareTo(object? i_obj)
        {
            return i_obj is MouseId other ? CompareTo(other) : -1;
        }

        public override int GetHashCode()
        {
            return m_id.GetHashCode();
        }

        public override string ToString()
        {
            return m_id.ToString();
        }

        private readonly int m_id = i_id;
    }
}
