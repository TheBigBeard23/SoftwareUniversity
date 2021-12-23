using System;
using System.Collections.Generic;

namespace CinemaTicket
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> daysOfTheWeekPrice = new Dictionary<string, int>();

            daysOfTheWeekPrice["Monday"] = 12;
            daysOfTheWeekPrice["Tuesday"] = 12;
            daysOfTheWeekPrice["Wednesday"] = 14;
            daysOfTheWeekPrice["Thursday"] = 14;
            daysOfTheWeekPrice["Friday"] = 12;
            daysOfTheWeekPrice["Saturday"] = 16;
            daysOfTheWeekPrice["Sunday"] = 16;

            string day = Console.ReadLine();

            Console.WriteLine(daysOfTheWeekPrice[day]);
        }
    }
}
