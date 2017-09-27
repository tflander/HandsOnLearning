using System;
using System.Collections.Generic;

namespace Katas
{
    public interface SubscriberService
    {
       List<string> GetSubscribersThatWillExpireBetweenNowAndDate(int day, int month, int year);
    }
}
