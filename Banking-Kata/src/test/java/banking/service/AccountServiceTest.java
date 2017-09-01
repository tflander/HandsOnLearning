package banking.service;

import static org.assertj.core.api.Assertions.assertThat;

import banking.model.Account;
import banking.model.Money;
import banking.persistence.FakeRepository;
import banking.persistence.Repository;
import org.assertj.core.api.Assertions;
import org.junit.Before;
import org.junit.Test;

import java.util.Optional;
import java.util.UUID;

public class AccountServiceTest {

  private AccountService accountService;
  private Repository<Account> repository;

  @Before
  public void setup() {
    repository = new FakeRepository<Account>();
    accountService = new AccountService(repository);
  }

  @Test
  public void openingAnAccountSavesItInTheAccountRepository() throws Exception {
    Account account = accountService.openNewAccount();
    Optional<Account> savedAccount = repository.findOne(account.getId());
    assertThat(savedAccount).isPresent();
  }

  @Test
  public void newAccountsStartWithZeroBalance() throws Exception {
    Money expectedBalance = Money.of("0.00");

    Account account = accountService.openNewAccount();
    Optional<Account> savedAccount = repository.findOne(account.getId());

    assertThat(savedAccount.get().getBalance()).isEqualTo(expectedBalance);
  }

  @Test
  public void depositAddsFundsToSavedAccount() throws Exception {
    Account account = new Account(Money.of("52.01"));
    repository.save(account);

    accountService.deposit(account.getId(), Money.of("12.34"));
    Optional<Account> savedAccount = repository.findOne(account.getId());

    assertThat(savedAccount.get().getBalance()).isEqualTo(Money.of("64.35"));
  }

  @Test
  public void depositThrowsErrorIfAccountDoesNotExist() throws Exception {
    UUID nonExistantAccountId = UUID.randomUUID();

    Assertions.assertThatThrownBy(() -> {
      accountService.deposit(nonExistantAccountId, Money.of("12.34"));
    }).hasMessage("Invalid accountId");
  }
  
  // TODO: What if you try to deposit a negative amount?

  @Test
  public void withdrawSubtractsFundsFromSavedAccount() throws Exception {
    Account account = new Account(Money.of("82.00"));
    repository.save(account);

    accountService.withdraw(account.getId(), Money.of("56.30"));
    Optional<Account> savedAccount = repository.findOne(account.getId());

    assertThat(savedAccount.get().getBalance()).isEqualTo(Money.of("25.70"));
  }

  @Test
  public void withdrawThrowsErrorIfAccountDoesNotExist() throws Exception {
    UUID nonExistantAccountId = UUID.randomUUID();

    Assertions.assertThatThrownBy(() -> {
      accountService.withdraw(nonExistantAccountId, Money.of("12.34"));
    }).hasMessage("Invalid accountId");
  }
  
  // TODO: What if you try to withdraw a negative amount?

}
