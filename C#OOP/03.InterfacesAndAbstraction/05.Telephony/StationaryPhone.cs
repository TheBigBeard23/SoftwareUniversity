using System;
using System.Linq;


namespace Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            if (number.Any(x => char.IsLetter(x)))
            {
                throw new ArgumentException(ExceptionMessages.InvalidNumberException);
            }
            else if (number.Length > 7)
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
