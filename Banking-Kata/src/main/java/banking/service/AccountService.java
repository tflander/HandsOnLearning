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

  public Account openNewAccount(Money startingBalance) {
    Account account = new Account(startingBalance);
    accountRepository.save(account);
    return account;
  }

  public void deposit(UUID accountId, Money amount) {
    Account account = findAccount(accountId);
    Account updatedAccount = account.cloneWithBalance(account.getBalance().plus(amount));
    accountRepository.save(updatedAccount);
  }

  public void withdraw(UUID accountId, Money amount) {
    Account account = findAccount(accountId);
    Account updatedAccount = account.cloneWithBalance(account.getBalance().minus(amount));
    accountRepository.save(updatedAccount);
  }

  private Account findAccount(UUID accountId) {
    return accountRepository.findOne(accountId).orElseThrow(() -> new NoSuchElementException("Invalid accountId"));
  }
}
