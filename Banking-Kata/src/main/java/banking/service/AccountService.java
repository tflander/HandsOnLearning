package banking.service;

import banking.model.Account;
import banking.model.Money;
import banking.persistence.Repository;

import java.util.NoSuchElementException;
import java.util.UUID;

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

  public void deposit(UUID accountId, Money amount) {
    Account account = accountRepository.findOne(accountId).orElseThrow(() -> new NoSuchElementException("Invalid accountId"));
    Account updatedAccount = account.cloneWithBalance(account.getBalance().plus(amount));
    accountRepository.save(updatedAccount);
  }

}
