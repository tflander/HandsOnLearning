using NUnit.Framework;
using RomanNumerals;

namespace Katas
{
    [TestFixture]
    public class IntegerToRomanConverterTest
    {
        [Test]
        [Ignore("Remove this line when you're ready to run the tests")]
        public void ShouldConvert16ToXVI()
        {
            var converter = new IntegerToRomanConverter();

            var actualResult = converter.Convert(16);
            var expectedResult = "XVI";

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
