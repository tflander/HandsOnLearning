import static org.junit.Assert.*;

import org.junit.Test;

public class RockPaperScissorsGameTest {

  @Test
  public void rockCrushesScissors() {
    RockPaperScissorsGame game = new RockPaperScissorsGame();
    
    String actualResult = game.determineWinner("rock", "scissors");
    String expectedResult = "rock beats scissors";
    
    assertEquals(expectedResult, actualResult);
  }
}
