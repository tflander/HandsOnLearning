import static org.junit.Assert.assertEquals;

import org.junit.Ignore;
import org.junit.Test;

public class RomanNumeralCalculatorTest {

  @Test
  @Ignore("Remove this line when you are ready to run this test")
  public void onePlusOneIsTwo() {
    RomanNumeralCalculator calculator = new RomanNumeralCalculator();

    String actualResult = calculator.add("I", "I");
    String expectedResult = "II";

    assertEquals(expectedResult, actualResult);
  }
}
