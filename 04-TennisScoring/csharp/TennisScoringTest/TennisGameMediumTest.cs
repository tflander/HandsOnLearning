using System;
using Xunit;

namespace Katas
{
    public class TennisGameMediumTest : BaseTennisGameTest
    {
        
        [Theory]
        [ClassData(typeof(BaseTennisTestData))]
        public void scoreIsCorrect(int p1Score, int p2Score, string expectedScore)
        {
            ITennisGame game = new TennisGameMedium("player1","player2");

            scorePoints(game, "player1", p1Score);
            scorePoints(game, "player2", p2Score);

            string actualScore = game.GetScore();
            Assert.Equal(expectedScore, actualScore);
        }
    }
}
