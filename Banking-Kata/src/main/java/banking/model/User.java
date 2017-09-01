package banking.model;

import java.util.UUID;

public class User implements Identifiable{
	private UUID id;
	private String emailAddress;
	
	private User(UUID id, String emailAddress) {
	  this.id = id;
	  this.emailAddress = emailAddress;
	}
	
	public User(String emailAddress) {
		this(UUID.randomUUID(), emailAddress);
	}

	@Override
	public UUID getId() {
		return id;
	}
	
	public String getEmailAddress() {
      return emailAddress;
    }
	
	public User cloneWithEmailAddress(String emailAddress) {
	  return new User(this.id, emailAddress);
	}
}
