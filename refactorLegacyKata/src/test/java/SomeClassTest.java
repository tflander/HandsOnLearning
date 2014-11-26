import static org.junit.Assert.*;

import org.junit.Test;

public class SomeClassTest {

	@Test
    public void shouldFailSometimesAndPassSometimesWhichIsAbsolutelyUseless() {
		SomeClass someClass = new SomeClass();
		assertEquals("Tofu", someClass.someMethod());
    }
}
