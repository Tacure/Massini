
using System.Numerics;

namespace Massini.Core.Math.Generators.Sequence
{
    public interface ISequenceGenerator<T> : IEnumerable<T>
        where T : unmanaged, INumber<T>
    {
    }
}
