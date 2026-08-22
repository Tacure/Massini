
using System.Numerics;
using Massini.Core.Math.Primitives;

namespace Massini.Core.Math.Results
{
    public readonly struct HitResult3D<T>(Vec3<T> i_hitPosition, bool i_isBack)
        where T : unmanaged, IFloatingPointIeee754<T>
    {
        public readonly Vec3<T> HitPosition = i_hitPosition;
        public readonly bool IsBack = i_isBack;

        public static HitResult3D<T> Miss => new(Vec3<T>.NaN, false);
    }
}
