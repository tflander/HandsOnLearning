using System;
using System.Collections.Generic;

namespace Katas
{
    public class RealSubscriberService : SubscriberService
    {
        Random random = new Random();
        public List<string> GetSubscribersThatWillExpireBetweenNowAndDate(int day, int month, int year)
        {
            if (random.NextDouble() < 0.5)
			{
				return null;
			}
			else
			{
                String[] strings = { "mysterious email" + random.Next()};
				return new List<string>(strings);
			}
        }
    }
}
