using System;

namespace DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            int dayOfWeek = int.Parse(Console.ReadLine());
            string[] days = new string[]
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            if (dayOfWeek < 1 || dayOfWeek > days.Length)
            {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                Console.WriteLine(days[dayOfWeek - 1]);
            }
        }
    }
}
