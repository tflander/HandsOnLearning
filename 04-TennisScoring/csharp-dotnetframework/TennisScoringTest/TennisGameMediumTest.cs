using System;
using NUnit.Framework;

namespace Katas
{
    [TestFixture]
    public class TennisGameMediumTest : BaseTennisGameTest
    {

        [Test, TestCaseSource(typeof(TennisTestData), "TestData")]
        public void scoreIsCorrect(int p1Score, int p2Score, string expectedScore)
        {
            ITennisGame game = new TennisGameMedium("player1","player2");

            scorePoints(game, "player1", p1Score);
            scorePoints(game, "player2", p2Score);

            string actualScore = game.GetScore();
            Assert.AreEqual(expectedScore, actualScore);
        }
    }
}
