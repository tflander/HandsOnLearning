package banking.model;

import java.util.UUID;

public class Account implements Identifiable {
  
  private final UUID id;
  private Money balance;
  
  private Account(UUID id, Money balance) {
    this.id = id;
    this.balance = balance;
  }

  public Account(Money startingBalance) {
    this(UUID.randomUUID(), startingBalance);
  }
  
  @Override
  public UUID getId() {
    return id;
  }

  public Money getBalance() {
    return balance;
  }

  public Account cloneWithBalance(Money balance) {
    return new Account(this.id, balance);
  }

}
