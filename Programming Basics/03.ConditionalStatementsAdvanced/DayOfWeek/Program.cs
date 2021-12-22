using System;
using System.Collections.Generic;

namespace DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> dayOfTheWeek = new Dictionary<int, string>();
            dayOfTheWeek[1] = "Monday";
            dayOfTheWeek[2] = "Tuesday";
            dayOfTheWeek[3] = "Wednesday";
            dayOfTheWeek[4] = "Thursday";
            dayOfTheWeek[5] = "Friday";
            dayOfTheWeek[6] = "Saturday";
            dayOfTheWeek[7] = "Sunday";

            int num = int.Parse(Console.ReadLine());

            if (dayOfTheWeek.ContainsKey(num))
            {
                Console.WriteLine(dayOfTheWeek[num]);
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
    }
}
