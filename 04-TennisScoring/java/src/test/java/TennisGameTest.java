import static org.junit.Assert.assertEquals;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.junit.runners.Parameterized;
import org.junit.runners.Parameterized.Parameters;

import java.util.Collection;

@RunWith(Parameterized.class)
public class TennisGameTest {

  private int player1Score;
  private int player2Score;
  private String expectedScore;

  @Parameters(name = " {0}-{1} is {2} ")
  public static Collection<Object[]> getAllScores() {
    return TestData.getTestCases();
  }

  public TennisGameTest(int player1Score, int player2Score, String expectedScore) {
    this.player1Score = player1Score;
    this.player2Score = player2Score;
    this.expectedScore = expectedScore;
  }

  @Test
  public void scoreShouldBeCorrect() {
    TennisGame game = new TennisGame("player1", "player2");

    scorePoints(game, "player1", this.player1Score);
    scorePoints(game, "player2", this.player2Score);

    assertEquals(this.expectedScore, game.getScore());
  }

  private void scorePoints(TennisGame game, String player, int points) {
    for (int i = 0; i < points; i++) {
      game.wonPoint(player);
    }
  }

}