using NUnit.Framework;
using RomanNumerals;

namespace Katas
{
    [TestFixture]
    public class RomanToIntegerConverterTest
    {
        [Test]
        [Ignore("Remove this line when you're ready to run the tests")]
        public void ShouldConvertsXVIto16()
        {
            var converter = new RomanToIntegerConverter();

            var actualResult = converter.Convert("XVI");
            var expectedResult = 16;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
