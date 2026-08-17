
using Massini.Math.Generators.Sequence;
using Xunit.Abstractions;

namespace Massini.Math.Tests
{
    public class Generators
    {
        public Generators(ITestOutputHelper i_output)
        {
            m_output = i_output;
        }

        [Fact]
        public void Range()
        {
            List<float> expected = [.. ExpectedRange];
            foreach (var value in new Range<float>(0.0f, 10.0f, 1.0f))
            {
                Assert.Equal(value, expected[0]);
                expected.RemoveAt(0);
            }

            expected = [.. ExpectedRange];
            foreach (var value in new Range<float>(0.0f, 10.0f, 1.0f, i_includeEnd: true))
            {
                Assert.Equal(value, expected[0]);
                expected.RemoveAt(0);
            }

            expected = [.. ExpectedRange];
            foreach (var value in new Range<float>(0.0f, 10.0f, -1.0f))
            {
                Assert.Equal(value, expected[^1]);
                expected.RemoveAt(expected.Count - 1);
            }

            expected = [.. ExpectedRange];
            foreach (var value in new Range<float>(10.0f, 0.0f, 1.0f, i_includeEnd: true))
            {
                Assert.Equal(value, expected[^1]);
                expected.RemoveAt(expected.Count - 1);
            }
        }

        [Fact]
        public void Primes()
        {
            List<int> expected = [.. ExpectedPrimes];
            foreach (var value in new Primes<int>(2, 31))
            {
                Assert.Equal(value, expected[0]);
                expected.RemoveAt(0);
            }
        }

        [Fact]
        public void Fibonacci()
        {
            List<int> expected = [.. ExpectedFibonacci];
            foreach (var value in new Fibonacci<int>(0, 55))
            {
                m_output.WriteLine(value.ToString());
                Assert.Equal(value, expected[0]);
                expected.RemoveAt(0);
            }
        }

        private readonly float[] ExpectedRange = [0.0f, 1.0f, 2.0f, 3.0f, 4.0f, 5.0f, 6.0f, 7.0f, 8.0f, 9.0f, 10.0f];

        private readonly int[] ExpectedPrimes = [2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31];

        private readonly int[] ExpectedFibonacci = [0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55];

        private readonly ITestOutputHelper m_output;
    }
}
