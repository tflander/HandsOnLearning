using System;
namespace Katas
{
    public class RenewalNotificationService
    {
		SubscriberService _subscriberService;
		private readonly EmailService _emailService;

		public RenewalNotificationService(SubscriberService subscriberService, EmailService emailService)
		{
			_subscriberService = subscriberService;
			_emailService = emailService;
		}

		public void notifyAtRiskSubscribers()
		{
			var emails = _subscriberService.GetSubscribersThatWillExpireBetweenNowAndDate(99, 99, 99);
			if(emails != null)
				_emailService.EmailMessage("Please renew your subscription to Ferret Fancy!", emails);
		}
    }
}
