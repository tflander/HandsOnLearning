import java.util.Arrays;
import java.util.Date;
import java.util.List;
import java.util.Random;

public class RealSubscriberService implements SubscriberService {
	
	Random random = new Random();


	@Override
	public List<String> getSubscribersThatWillExpireBetween(Date now, Date expiration) {
		if(random.nextBoolean()) {
			return null;
		} else {
			String[] strings = {"mysterious email" + random.nextInt()};
			return Arrays.asList(strings);
		}
	}
}
