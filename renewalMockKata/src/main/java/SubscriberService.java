import java.util.Date;
import java.util.List;

public interface SubscriberService {
	
	public List<String> getSubscribersThatWillExpireBetween(Date now, Date expiration);

}
