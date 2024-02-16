using Telephony.Models;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ICallable stationaryPhone = new StationaryPhone();
            Smartphone smartphone = new Smartphone();

            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] sites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (string number in numbers)
            {
                if (number.Length == 10)
                {
                    Console.WriteLine(smartphone.Call(number));
                }
                else if (number.Length == 7)
                {
                    Console.WriteLine(stationaryPhone.Call(number));
                }
            }

            foreach (string site in sites)
            {
                Console.WriteLine(smartphone.Brows(site));
            }



        }
    }
}