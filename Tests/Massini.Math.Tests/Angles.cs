
using Massini.Core.Math;
using Massini.Core.Math.Primitives;

namespace Massini.Math.Tests;

public class Angles
{
    const float TOLERANCE = 0.001f;

    [Fact]
    public void DegreesToRadians90()
    {
        Rad<float> rads = Rad<float>.DegreesToRadians((Deg<float>)90.0f);
        Assert.Equal(Math<float>.Pi / 2.0f, (float)rads, TOLERANCE);
    }

    [Fact]
    public void RadiansToDegrees90()
    {
        Deg<float> degrees = Deg<float>.RadiansToDegrees(Rad<float>.Pi / 2.0f);
        Assert.Equal(90.0f, (float)degrees, TOLERANCE);
    }

    [Fact]
    public void Sin()
    {
        Rad<float> a0 = Rad<float>.Zero;
        Rad<float> a45 = Rad<float>.Pi / 4.0f;
        Rad<float> a90 = Rad<float>.Pi / 2.0f;

        Assert.Equal(0.0f, Rad<float>.Sin(a0), TOLERANCE);
        Assert.Equal(0.70710678118f, Rad<float>.Sin(a45), TOLERANCE);
        Assert.Equal(1.0f, Rad<float>.Sin(a90), TOLERANCE);
    }

    [Fact]
    public void Cos()
    {
        Rad<float> a0 = Rad<float>.Zero;
        Rad<float> a45 = Rad<float>.Pi / 4.0f;
        Rad<float> a90 = Rad<float>.Pi / 2.0f;

        Assert.Equal(1.0f, Rad<float>.Cos(a0), TOLERANCE);
        Assert.Equal(0.70710678118f, Rad<float>.Cos(a45), TOLERANCE);
        Assert.Equal(0.0f, Rad<float>.Cos(a90), TOLERANCE);
    }
}
