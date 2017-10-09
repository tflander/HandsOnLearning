using System;
using NUnit.Framework;

namespace Katas
{
    [TestFixture]
    public class TennisGameTest
    {

        [Test, TestCaseSource(typeof(TennisTestData), nameof(TennisTestData.TestData))]
        public void ScoreShouldBeDisplayedCorrectly(int p1Score, int p2Score, string expectedScore)
        {
            var game = new TennisGame("player1","player2");

            ScorePoints(game, "player1", p1Score);
            ScorePoints(game, "player2", p2Score);

            var actualScore = game.GetScore();
            Assert.AreEqual(expectedScore, actualScore);
        }

        private static void ScorePoints(ITennisGame game, string playerName, int points)
        {
            for (var i = 0; i < points; i++)
            {
                game.WonPoint(playerName);
            }
        }
    }
}
