import static org.junit.Assert.*;

import org.junit.Ignore;
import org.junit.Test;

@Ignore("Remove this line when you're ready to run the tests")
public class RomanNumeralConverterTest {

	@Test
    public void shouldReturn1ForI() {
		Integer actualResult = RomanNumeralConverter.convert("I");
		Integer expectedResult = 1;
        assertEquals(expectedResult, actualResult);
    }
}
