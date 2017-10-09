import static org.junit.Assert.assertEquals;

import org.junit.Ignore;
import org.junit.Test;

public class RomanToIntegerConverterTest {

  @Test
  @Ignore("Remove this line when you are ready to run this test")
  public void canConvertXVItoSixteen() throws Exception {
    RomanToIntegerConverter converter = new RomanToIntegerConverter();

    assertEquals(1, converter.convertToInteger("XVI"));
  }

}
