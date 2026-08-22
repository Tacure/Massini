
using System.Numerics;

namespace Massini.Core.Math.Results
{
    public readonly struct RaycastResult3D<T>(HitResult3D<T> i_hitA, HitResult3D<T> i_hitB, bool i_intersect, bool i_inside)
        where T : unmanaged, IFloatingPointIeee754<T>
    {
        public readonly HitResult3D<T> HitA = i_hitA;
        public readonly HitResult3D<T> HitB = i_hitB;
        public readonly bool Intersect = i_intersect;
        public readonly bool Inside = i_inside;
    }
}
