package banking.service;

import banking.model.Account;
import banking.persistence.Repository;

public class AccountService {

  private Repository<Account> accountRepository;

  public AccountService(Repository<Account> accountRepository) {
    this.accountRepository = accountRepository;
  }

  public Account openNewAccount() {
    Account account = new Account();
    accountRepository.save(account);
    return account;
  }

}
