using System;
namespace Katas
{
    public class BaseTennisGameTest
    {
        protected void scorePoints(ITennisGame game, string playerName, int points)
		{
			for (int i = 0; i < points; i++)
			{
				game.WonPoint(playerName);
			}
		}
    }
}
