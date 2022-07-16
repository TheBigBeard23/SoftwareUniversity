using System;
using System.Linq;


namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Browse(string site)
        {
            if (site.Any(x => char.IsDigit(x)))
            {
                throw new ArgumentException(ExceptionMessages.InvalidUrlException);
            }
            return $"Browsing: {site}!";
        }

        public string Call(string number)
        {
            if (number.Length > 7)
            {
                return $"Calling... {number}";
            }
            else
            {
                return $"Dialing... {number}";
            }
        }
    }
}
