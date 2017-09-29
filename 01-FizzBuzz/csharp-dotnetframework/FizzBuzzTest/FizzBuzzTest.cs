using System;
using NUnit.Framework;

namespace Katas
{
    [TestFixture]
    public class NUnitTest1
    {
        [Test]
        public void ShouldReturn1For1()
        {
            FizzBuzz fizzBuzz = new FizzBuzz();
            string actualReturnValue = fizzBuzz.Process(1);
            string expectedReturnValue = "1";
            Assert.AreEqual(expectedReturnValue, actualReturnValue);
        }
    }
}