
using Massini.Math;
using Massini.Math.Geometry;
using Massini.Math.Primitives;

namespace Massini.Math.Tests
{
    public class Vectors
    {
        const float TOLERANCE = 0.0001f;

        [Fact]
        public void Addition()
        {
            Vec3<float> a = new(1.0f, 2.0f, 3.0f);
            Vec3<float> b = new(4.0f, 5.0f, 6.0f);
            Vec3<float> c = a + b;

            Assert.Equal(5.0f, c.p_x, TOLERANCE);
            Assert.Equal(7.0f, c.p_y, TOLERANCE);
            Assert.Equal(9.0f, c.p_z, TOLERANCE);
        }

        [Fact]
        public void Subtraction()
        {
            Vec3<float> a = new(1.0f, 2.0f, 3.0f);
            Vec3<float> b = new(4.0f, 5.0f, 6.0f);
            Vec3<float> c = a - b;

            Assert.Equal(-3.0f, c.p_x, TOLERANCE);
            Assert.Equal(-3.0f, c.p_y, TOLERANCE);
            Assert.Equal(-3.0f, c.p_z, TOLERANCE);
        }

        [Fact]
        public void Magnitude()
        {
            Vec3<float> a = new(1.0f, 2.0f, 3.0f);
            float mag = Vec3<float>.Magnitude(a);
            Assert.Equal(3.74165738677f, mag, TOLERANCE);

            float squaredMag = Vec3<float>.SquaredMagnitude(a);
            Assert.Equal(14.0f, squaredMag, TOLERANCE);
        }

        [Fact]
        public void Products()
        {
            Vec3<float> a = new(1.0f, 2.0f, 3.0f);
            Vec3<float> b = new(4.0f, 5.0f, 6.0f);
            float dot = Vec3<float>.Dot(a, b);
            Assert.Equal(32.0f, dot, TOLERANCE);

            Vec3<float> cross = Vec3<float>.Cross(a, b);
            Assert.Equal(-3.0f, cross.p_x, TOLERANCE);
            Assert.Equal(6.0f, cross.p_y, TOLERANCE);
            Assert.Equal(-3.0f, cross.p_z, TOLERANCE);
        }

        [Fact]
        public void Lerp()
        {
            Vec3<float> a = new(1.0f, 2.0f, 3.0f);
            Vec3<float> b = new(4.0f, 5.0f, 6.0f);
            Vec3<float> ll = Vec3<float>.Lerp(a, b, 0.5f);
            Assert.Equal(2.5f, ll.p_x, TOLERANCE);
            Assert.Equal(3.5f, ll.p_y, TOLERANCE);
            Assert.Equal(4.5f, ll.p_z, TOLERANCE);

            Vec3<float> sl = Vec3<float>.Slerp(a, b, 0.5f);
            Assert.Equal(1.0f, sl.p_x, TOLERANCE);
            Assert.Equal(2.0f, sl.p_y, TOLERANCE);
            Assert.Equal(3.0f, sl.p_z, TOLERANCE);
        }

        [Fact]
        public void Normalize()
        {
            Vec3<float> a = new(1.0f, 2.0f, 3.0f);
            Vec3<float> b = Vec3<float>.Normalize(a);
            Assert.Equal(0.26726124191f, b.p_x, TOLERANCE);
            Assert.Equal(0.53452248382f, b.p_y, TOLERANCE);
            Assert.Equal(0.80178372573f, b.p_z, TOLERANCE);
        }

        [Fact]
        public void Distance()
        {
            Vec3<float> a = new(1.0f, 2.0f, 3.0f);
            Vec3<float> b = new(4.0f, 5.0f, 6.0f);
            float dist = Vec3<float>.Distance(a, b);
            Assert.Equal(5.1961524227f, dist, TOLERANCE);

            Plane<float> p = new(Vec3<float>.Zero, Vec3<float>.UnitX);
            dist = Vec3<float>.Distance(a, p);
            Assert.Equal(1.0f, dist, TOLERANCE);

            Segment3D<float> s = new(Vec3<float>.UnitX, Vec3<float>.UnitY);
            dist = Vec3<float>.Distance(a, s);
            Assert.Equal(3.31662488f, dist, TOLERANCE);
        }

        [Fact]
        public void Comparisons()
        {
            Vec3<float> a = new(1.0f, 2.0f, 3.0f);
            Vec3<float> b = new(1.0f, 2.0f, 3.0f);
            Assert.True(a == b);
            Assert.False(a != b);

            Assert.True(Vec3<float>.NearlyEqual(a, b, TOLERANCE));
        }

        [Fact]
        public void Reflection()
        {
            Vec3<float> direction = Vec3<float>.Normalize(new Vec3<float>(1.0f, -1.0f, 0.0f));
            Vec3<float> reflected = Vec3<float>.Reflect(direction, Vec3<float>.UnitY);

            Assert.Equal(0.707106769f, reflected.p_x, TOLERANCE);
            Assert.Equal(0.707106769f, reflected.p_y, TOLERANCE);
            Assert.Equal(0.0f, reflected.p_z, TOLERANCE);

            Assert.Equal(1.0f, Vec3<float>.Magnitude(reflected), TOLERANCE);
        }

        [Fact]
        public void Resize()
        {
            Vec3<float> a = new(1.0f, 2.0f, 3.0f);
            Vec3<float> b = Vec3<float>.Resize(a, 2.0f);
            Assert.Equal(0.534522474f, b.p_x, TOLERANCE);
            Assert.Equal(1.069044948f, b.p_y, TOLERANCE);
            Assert.Equal(1.603567422f, b.p_z, TOLERANCE);
        }
    }
}
