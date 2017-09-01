package banking.model;

import static org.assertj.core.api.Assertions.assertThat;

import org.junit.Test;

public class AccountTest {

  @Test
  public void canSpecifyAStartingBalance() throws Exception {
    Account account = new Account(Money.of("65.98"));

    assertThat(account.getBalance()).isEqualTo(Money.of("65.98"));
  }
  
  @Test
  public void eachAccountHasAUniqueId() throws Exception {
    Account account1 = new Account(Money.of("1.23"));
    Account account2 = new Account(Money.of("1.23"));
    
    assertThat(account1.getId()).isNotEqualTo(account2.getId());
  }

}
