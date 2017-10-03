namespace Katas
{
    public class AccountsService
    {
        public Account FindAccount(int id)
        {
            return new Account(new Money(123, "en-US"));
        }

        public void OpenNewAccount(Money startingBalance)
        {
            Account account = new Account(startingBalance);
        }

        public void Deposit(int accountId, Money amount)
        {
            Account account = FindAccount(accountId);
            Account updatedAccount = account.cloneWithBalance(account.balance + amount);
        }

        public void withdraw(int accountId, Money amount)
        {
            Account account = FindAccount(accountId);
            Account updatedAccount = account.cloneWithBalance(account.balance - amount);
        }
    }
}