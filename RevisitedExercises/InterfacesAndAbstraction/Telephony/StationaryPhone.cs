using Telephony.Models;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        private static string[] numbers = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
        public string Call(string number)
        {
            if (number.Any(n => !numbers.Contains(n.ToString())))
            {
                return "Invalid number!";
            }
            return $"Dialing... {number}";
        }
    }
}
