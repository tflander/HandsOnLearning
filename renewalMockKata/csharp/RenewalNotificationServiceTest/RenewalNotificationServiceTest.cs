using System;
using Xunit;

namespace Katas
{
    public class RenewalNotificationServiceTest
    {
        [Fact]
        public void notifyingAtRiskSubscribersShouldSendEmails()
        {
			RenewalNotificationService renewalNotificationService = new RenewalNotificationService(new RealSubscriberService(), null);
			renewalNotificationService.notifyAtRiskSubscribers();
			// Uh oh... how will we know what happened if the method doesn't return any information?
		}
    }
}
