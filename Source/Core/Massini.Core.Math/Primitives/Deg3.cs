
using System.Numerics;
using Massini.Math.Primitives;

namespace Massini.Math.Primitives
{
    public partial struct Deg3<T>
        where T : unmanaged, IFloatingPointIeee754<T>
    {
        public Deg<T> p_phi = Deg<T>.Zero;
        public Deg<T> p_theta = Deg<T>.Zero;
        public Deg<T> p_psi = Deg<T>.Zero;

        public Deg3() { }

        public Deg3(Deg<T> i_phi, Deg<T> i_theta, Deg<T> i_psi)
        {
            p_phi = i_phi;
            p_theta = i_theta;
            p_psi = i_psi;
        }
    }

    public static class Deg3
    {
        extension<T>(Deg3<T>)
            where T : unmanaged, IFloatingPointIeee754<T>
        {
            public static Deg3<T> RadiansToDegrees(Rad3<T> i_radians)
            {
                Deg<T> phi = Deg<T>.RadiansToDegrees(i_radians.p_phi);
                Deg<T> theta = Deg<T>.RadiansToDegrees(i_radians.p_theta);
                Deg<T> psi = Deg<T>.RadiansToDegrees(i_radians.p_psi);
                return new Deg3<T>(phi, theta, psi);
            }
        }
    }
}
