using System;
using Telephony.Models;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();

            ICallable stationaryPhone = new StationaryPhone();
            IBrowsable smartPhone = new Smartphone();

            foreach (var number in numbers)
            {

                try
                {
                    Console.WriteLine(stationaryPhone.Call(number));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }

            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(smartPhone.Browse(url));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

    }
}

