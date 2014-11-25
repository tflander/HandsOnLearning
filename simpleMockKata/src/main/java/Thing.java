import java.util.Random;

public class Thing implements SomeInterfaceForThings {
	
	Random random = new Random();

	public boolean thingOne() {
		return random.nextBoolean();
	}
	public boolean thingTwo() {
		return random.nextBoolean();
	}
	public boolean thingThree() {
		return random.nextBoolean();
	}

}
