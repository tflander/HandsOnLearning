using System;
using NUnit.Framework;

namespace Katas
{
    [TestFixture]
    public class NUnitTest1
    {
        [Test]
        [Ignore("Because")]
        public void rockShouldCrushScissors()
        {
            RockPaperScissors game = new RockPaperScissors();

            string actualResult = game.determineWinner("rock", "scissors");
            string expectedResult = "rock beats scissors";

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}