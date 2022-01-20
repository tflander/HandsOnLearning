using System;
using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Katas
{
    public class RenewalNotificationNsubstituteServiceTest
    {
        [Fact]
        public void NotifyingAtRiskSubscribersShouldSendEmails()
        {
	        var subscribersExpiringInTheNextThreeMonths = new List<string> { "a@b.com", "c@d.com" };
	        var mockSubscriberService = Substitute.For<SubscriberService>();
	        var mockEmailService = Substitute.For<EmailService>();

	        mockSubscriberService
		        .GetSubscribersThatWillExpireBetweenNowAndDate(Arg.Any<int>(), Arg.Any<int>(), Arg.Any<int>())
		        .Returns(subscribersExpiringInTheNextThreeMonths);
	        
			var renewalNotificationService = new RenewalNotificationService(
				mockSubscriberService, 
				mockEmailService);
			
			renewalNotificationService.notifyAtRiskSubscribers();
			
			// mockEmailService.EmailMessage(Arg.Any<string>(), Arg.Any<List<string>>());
			
			mockEmailService.Received().EmailMessage(Arg.Any<string>(), Arg.Any<List<string>>());
			
			// mockEmailService.NumberOfCalls.Should().Be(1);
			// mockEmailService.LastEmailAddressesSent.Should().BeEquivalentTo(subscribersExpiringInTheNextThreeMonths);
			// mockEmailService.LastEmailMessage.Should().Be("Please renew your subscription to Ferret Fancy!");
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
}
