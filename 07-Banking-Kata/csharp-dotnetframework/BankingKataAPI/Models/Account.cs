using System;
namespace Katas
{
    public class Account : Identifiable
    {
        public Guid id { get; private set; }
        public Money balance { get; private set; }

        private Account(Guid id, Money balance)
		{
			this.id = id;
			this.balance = balance;
		}

		public Account(Money startingBalance)
		{
            this.id = Guid.NewGuid();
            this.balance = startingBalance;
		}

        public Guid GetId()
        {
            return id;
        }

		public Account cloneWithBalance(Money balance)
		{
			return new Account(this.id, balance);
		}
    }
}
