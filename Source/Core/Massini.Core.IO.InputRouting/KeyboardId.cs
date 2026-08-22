namespace Massini.Core.IO.InputRouting
{
    public readonly struct KeyboardId(int i_id = -1) : IEquatable<KeyboardId>, IComparable<KeyboardId>, IComparable
    {
        public static implicit operator KeyboardId(int i_id) => new(i_id);
        public static explicit operator int(KeyboardId i_id) => i_id.m_id;

        public static bool operator ==(KeyboardId i_gamepadId1, KeyboardId i_gamepadId2)
            => i_gamepadId1.m_id == i_gamepadId2.m_id;

        public static bool operator !=(KeyboardId i_gamepadId1, KeyboardId i_gamepadId2)
            => i_gamepadId1.m_id != i_gamepadId2.m_id;

        public static bool operator <(KeyboardId i_gamepadId1, KeyboardId i_gamepadId2)
            => i_gamepadId1.m_id < i_gamepadId2.m_id;

        public static bool operator <=(KeyboardId i_gamepadId1, KeyboardId i_gamepadId2)
            => i_gamepadId1.m_id <= i_gamepadId2.m_id;

        public static bool operator >(KeyboardId i_gamepadId1, KeyboardId i_gamepadId2)
            => i_gamepadId1.m_id > i_gamepadId2.m_id;

        public static bool operator >=(KeyboardId i_gamepadId1, KeyboardId i_gamepadId2)
            => i_gamepadId1.m_id >= i_gamepadId2.m_id;

        public bool Equals(KeyboardId i_other)
        {
            return m_id == i_other.m_id;
        }

        public int CompareTo(KeyboardId i_other)
        {
            return m_id.CompareTo(i_other.m_id);
        }

        public override bool Equals(object? i_obj)
        {
            return i_obj is KeyboardId other && Equals(other);
        }

        public int CompareTo(object? i_obj)
        {
            return i_obj is KeyboardId other ? CompareTo(other) : -1;
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
