using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Katas
{
    public class Account : Identifiable
    {
        public Guid id { get; set; }
        
        [NotMapped]
        public Money balance
        {
            get
            {
                return new Money(DbBalance, "en-US");
            }
            set
            {
                DbBalance = balance.Amount;
            }
        }
        public decimal DbBalance { get; set; }

        private Account(Guid id, Money balance)
		{
			this.id = id;
			DbBalance = balance.Amount;
		}

        public Account(decimal startingBalance)
        {
            this.id = Guid.NewGuid();
            this.DbBalance = startingBalance;
        }

        public Account(Money startingBalance)
		{
            this.id = Guid.NewGuid();
            this.DbBalance = startingBalance.Amount;
		}
        public Account()
        {

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
