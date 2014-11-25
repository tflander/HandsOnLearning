import static org.junit.Assert.*;

import org.junit.Test;

public class RomanNumeralConverterTest {

	@Test
    public void shouldReturn1ForI() {
		Integer actualResult = RomanNumeralConverter.convert("I");
		Integer expectedResult = 1;
        assertEquals(expectedResult, actualResult);
    }
}
