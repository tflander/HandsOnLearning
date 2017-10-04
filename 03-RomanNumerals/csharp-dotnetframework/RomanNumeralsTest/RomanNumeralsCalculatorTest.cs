using NUnit.Framework;

namespace Katas
{
    [TestFixture]
    public class RomanNumeralCalculatorTest
    {
        [Test]
        [Ignore("Remove this line when you're ready to run the tests")]
        public void ShouldReturnIIforIplusI()
        {
            var calculator = new RomanNumeralCalculator();

            var actualResult = calculator.Add("I", "I");
            var expectedResult = "II";

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
