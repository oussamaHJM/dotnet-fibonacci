using System;
using Xunit;

namespace Fibonacci.Tests
{
    public class FibonacciunitTest
    {
        [Fact]
        public void Execute44ShouldRetrun701408733()
        {
            var result = Fibonacci.Compute(new[] { "44" });
            Assert.Equal(701408733, result[0]);
        }
    }
}
