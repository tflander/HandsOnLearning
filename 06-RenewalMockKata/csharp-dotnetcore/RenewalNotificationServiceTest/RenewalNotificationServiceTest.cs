using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Katas
{
    public class RenewalNotificationServiceTest
    {
        [Fact]
        public void NotifyingAtRiskSubscribersShouldSendEmails()
        {
	        var subscribersExpiringInTheNextThreeMonths = new List<string> { "a@b.com", "c@d.com" };
	        var mockSubscriberService = new MockSubscriberService(subscribersExpiringInTheNextThreeMonths);
	        var mockEmailService = new MockEmailService();
	        
			var renewalNotificationService = new RenewalNotificationService(
				mockSubscriberService, 
				mockEmailService);
			
			renewalNotificationService.notifyAtRiskSubscribers();
			
			mockEmailService.NumberOfCalls.Should().Be(1);
			mockEmailService.LastEmailAddressesSent.Should().BeEquivalentTo(subscribersExpiringInTheNextThreeMonths);
			mockEmailService.LastEmailMessage.Should().Be("Please renew your subscription to Ferret Fancy!");
        }
        
        [Fact]
        public void EmailServiceNotCalledWhenNoSubscribersAreExpiring()
        {
	        var mockSubscriberService = new MockSubscriberService(subscribersExpiringInTheNextThreeMonths: null);
	        var mockEmailService = new MockEmailService();
	        
	        var renewalNotificationService = new RenewalNotificationService(
		        mockSubscriberService, 
		        mockEmailService);
			
	        renewalNotificationService.notifyAtRiskSubscribers();

	        mockEmailService.NumberOfCalls.Should().Be(0);
        }
        
        // He asks you to write a program that will email his subscribers that are 
        // within three months of relapsing on their subscriptions the message "Please renew your subscription to Ferret Fancy!"
        
        //   Verify the date sent to the subscriber service is three months in the future.
    }

    public class MockEmailService : EmailService
    {
	    public void EmailMessage(string message, List<string> emails)
	    {
		    LastEmailAddressesSent = emails;
		    LastEmailMessage = message;
		    ++NumberOfCalls;
	    }

	    public List<string> LastEmailAddressesSent { get; private set; }
	    public string LastEmailMessage { get; private set; }
	    public int NumberOfCalls { get; private set; } = 0;
    }

    public class MockSubscriberService : SubscriberService
    {
	    private readonly List<string> _subscribersExpiringInTheNextThreeMonths;

	    public MockSubscriberService(List<string> subscribersExpiringInTheNextThreeMonths)
	    {
		    _subscribersExpiringInTheNextThreeMonths = subscribersExpiringInTheNextThreeMonths;
	    }

	    public List<string> GetSubscribersThatWillExpireBetweenNowAndDate(int day, int month, int year)
	    {
		    return _subscribersExpiringInTheNextThreeMonths;
	    }
    }
}
