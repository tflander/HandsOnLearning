using System;
namespace Katas
{
    public interface ITennisGame
    {
        string GetScore();
        void WonPoint(string player);
    }
}
