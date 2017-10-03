using NUnit.Framework;

namespace Katas
{
    [TestFixture]
    public class RomanNumeralsTest
    {
        [Test]
        [Ignore("Remove this line when you're ready to run the tests")]
        public void TestMethod1()
        {
            RomanNumeralsCalculator calculator = new RomanNumeralsCalculator();

            string actualResult = calculator.add("I", "I");
            string expectedResult = "II";

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
