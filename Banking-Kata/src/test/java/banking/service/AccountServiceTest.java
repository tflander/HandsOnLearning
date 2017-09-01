package banking.service;

import static org.assertj.core.api.Assertions.assertThat;

import banking.model.Account;
import banking.model.Money;
import banking.persistence.FakeRepository;
import banking.persistence.Repository;
import org.junit.Before;
import org.junit.Test;

import java.util.Optional;

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

}
