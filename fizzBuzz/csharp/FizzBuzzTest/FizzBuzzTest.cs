using System;
using Xunit;

namespace Katas
{
    public class FizzBuzzTest
    {
        [Fact]
        public void ShouldReturn1For1()
        {
            FizzBuzz fizzBuzz = new FizzBuzz();
            string actualReturnValue = fizzBuzz.Process(1);
            string expectedReturnValue = "1";
            Assert.Equal(expectedReturnValue, actualReturnValue);
        }
    }
}
