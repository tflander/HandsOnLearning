using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Katas
{
    public class AccountsService
    {
        private readonly ApiContext _context;
        public AccountsService(ApiContext context)
        {
            this._context = context;
        }

        public async Task<Account> FindAccount(Guid id)
        {
            return await this._context.Accounts.FirstAsync(a => a.id == id);
        }

        public async void OpenNewAccount(decimal startingBalance)
        {
            Account account = new Account(startingBalance);
            await this._context.Accounts.AddAsync(account);
            this._context.SaveChanges();
        }

        public async Task Deposit(Guid accountId, decimal amount)
        {
            Account account = await FindAccount(accountId);
            Account updatedAccount = account.cloneWithBalance(account.balance + amount);
            this._context.Entry(account).CurrentValues.SetValues(updatedAccount);
            this._context.SaveChanges();
        }

        public void DeleteAccount(Guid accountId)
        {
            Account accountToDelete = new Account();
            accountToDelete.id = accountId;
            this._context.Accounts.Remove(accountToDelete);
            this._context.SaveChanges();
        }

        public async Task withdraw(Guid accountId, Money amount)
        {
            Account account = await FindAccount(accountId);
            Account updatedAccount = account.cloneWithBalance(account.balance - amount);
            await this._context.Accounts.AddAsync(updatedAccount);
            this._context.SaveChanges();
        }

        public Task<Account[]> retrieveAll()
        {
            return  _context.Accounts.ToArrayAsync();
        }
    }
}