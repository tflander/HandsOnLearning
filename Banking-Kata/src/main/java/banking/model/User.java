package banking.model;

import java.util.UUID;

public class User implements Identifiable{
	private UUID id = UUID.randomUUID();
	private String emailAddress;
	
	public User(String emailAddress) {
		this.emailAddress = emailAddress;
	}

	@Override
	public UUID getId() {
		return id;
	}
}
