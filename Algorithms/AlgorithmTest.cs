using System;
using Xunit;

namespace DeveloperSample.Algorithms
{
    public class AlgorithmTest
    {
        [Theory]
        [InlineData(1, 0)]
        [InlineData(1, 1)]
        [InlineData(24, 4)]
        [InlineData(120, 5)]
        public void CanGetFactorial(int expected,int input)
        {
            Assert.Equal(expected, Algorithms.GetFactorial(input));
        }
        
        [Fact]
        public void CanGetFactorial_InputNegative1_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(()=> Algorithms.GetFactorial(-1));
        }

        [Theory]
        [InlineData("")]
        [InlineData("", null)]
        [InlineData("a","a")]
        [InlineData("a and b","a", "b")]
        [InlineData("a, b and c","a", "b", "c")]
        [InlineData("a, b, c and d","a", "b", "c","d")]
        public void CanFormatSeparators(string expected, params string[] input)
        {
            Assert.Equal(expected, Algorithms.FormatSeparators(input));
        }
    }
}