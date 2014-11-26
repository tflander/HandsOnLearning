import static org.junit.Assert.*;

import org.junit.Test;

public class IntegrationTest {

    @Test
    public void noNamesShouldReturnNothing() {
        Integration integration = new Integration();
        String actualReturnValue = integration.process("");
        String expectedReturnValue = "";
        assertEquals(expectedReturnValue, actualReturnValue);
    }
}