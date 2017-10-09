import static org.junit.Assert.assertEquals;

import org.junit.Ignore;
import org.junit.Test;

public class IntegerToRomanConverterTest {

  @Test
  @Ignore("Remove this line when you are ready to run this test")
  public void convertsSixteenToXVI() throws Exception {
    IntegerToRomanConverter converter = new IntegerToRomanConverter();

    assertEquals("XVI", converter.convertToInteger(16));
  }

}
