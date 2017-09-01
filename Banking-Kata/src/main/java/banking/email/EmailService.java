package banking.email;

import java.util.UUID;

public interface EmailService {
	public UUID sendMessage(String emailAddress, String message);
}
