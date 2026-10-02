
namespace Massini.Core.Functional
{
    public readonly struct None : IEquatable<None>
    {
        public static None none()
        {
            return new None();
        }
        
        public bool Equals(None i_other)
        {
            return true; // None is always equal to None.
        }

        public override bool Equals(object? i_obj)
        {
            return i_obj is None other && Equals(other);
        }

        public override int GetHashCode()
        {
            return 0; // All "nones" are exactly equal.
        }
    }   
}