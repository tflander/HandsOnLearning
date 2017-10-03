using System;
namespace Katas
{
    public class User : Identifiable
    {
        public Guid id { get; private set; }
        public string emailAddress { get; private set; }

        private User(Guid id, string emailAddress)
		{
			this.id = id;
			this.emailAddress = emailAddress;
		}

		public User(String emailAddress)
		{
            this.id = Guid.NewGuid();
            this.emailAddress = emailAddress;
		}

        public Guid GetId()
        {
            return id;
        }

		public User cloneWithEmailAddress(string emailAddress)
		{
			return new User(this.id, emailAddress);
		}
    }
}
