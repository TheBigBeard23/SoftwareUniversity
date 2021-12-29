using System;

namespace TennisRanklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int tournamentsCount = int.Parse(Console.ReadLine());
            int startPoints = int.Parse(Console.ReadLine());

            double winCount = 0;
            int tournamentsPoints = 0;
            for (int i = 0; i < tournamentsCount; i++)
            {
                string status = Console.ReadLine();

                switch (status)
                {
                    case "W":
                        startPoints += 2000;
                        winCount++;
                        tournamentsPoints += 2000;
                        break;
                    case "F":
                        startPoints += 1200;
                        tournamentsPoints += 1200;
                        break;
                    case "SF":
                        startPoints += 720;
                        tournamentsPoints += 720;
                        break;
                    default:
                        break;
                }

            }
            Console.WriteLine($"Final points: {startPoints}");
            Console.WriteLine($"Average points: {tournamentsPoints / tournamentsCount}");
            Console.WriteLine($"{winCount / tournamentsCount * 100:f2}%");
        }
    }
}
