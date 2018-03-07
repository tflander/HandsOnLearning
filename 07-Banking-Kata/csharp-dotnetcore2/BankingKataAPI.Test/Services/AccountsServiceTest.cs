using System;
using BankingKataAPI.Models;
using BankingKataAPI.Services;
using BankingKataAPI.Test.Persistence;
using Xunit;

namespace BankingKataAPI.Test.Services
{
    public class AccountsServiceTest
    {
        private readonly FakeRepository<Account> _repository;
        private readonly AccountsService _service;

        public AccountsServiceTest()
        {
            _repository = new FakeRepository<Account>();
            _service = new AccountsService(_repository);
        }

        [Fact]
        public void OpeningAnAccountSavesItInTheAccountRepository()
        {
            var account = _service.OpenNewAccount(new Money());
            Assert.NotNull(_repository.FindOne(account.GetId()));
        }

        [Fact]
        public void NewAccountsStartWithCorrectBalance()
        {
            var expectedBalance = new Money(7.11m);

            var account = _service.OpenNewAccount(expectedBalance);
            var savedAccount = _repository.FindOne(account.GetId());

            Assert.Equal(expectedBalance, savedAccount.Balance);
        }

        [Fact]
        public void FindAccountFindsItFromTheRepository()
        {
            var expectedBalance= new Money(12.34m);
            var account = new Account(expectedBalance);
            _repository.Save(account);
    
            var savedAccount = _service.FindAccount(account.GetId());
            Assert.Equal(expectedBalance, savedAccount.Balance);
        }

        [Fact]
        public void FindAccountThrowsAnErrorIfAccountIsNotFound()
        {
            var nonExistantAccountId = Guid.NewGuid();

            var exception = Assert.Throws<Exception>(() => _service.FindAccount(nonExistantAccountId));
            Assert.Equal("Invalid account", exception.Message);
        }
    }
}
