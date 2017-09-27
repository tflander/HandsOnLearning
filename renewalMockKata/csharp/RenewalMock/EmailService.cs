using System;
using System.Collections.Generic;

namespace Katas
{
    public interface EmailService
    {
        void EmailMessage(String message, List<String> emails);
    }
}
