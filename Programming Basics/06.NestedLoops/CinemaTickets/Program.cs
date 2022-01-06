using System;
using System.Collections.Generic;

namespace CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> ticketsCountByType = new Dictionary<string, int>()
            {
                ["student"] = 0,
                ["standard"] = 0,
                ["kids"] = 0

            };

            Dictionary<string, double> occupiedSeatsByMovie = new Dictionary<string, double>();

            double totalSoldTickets = 0.0;

            while (true)
            {
              string input = Console.ReadLine();

                if (input == "Finish")
                {
                    break;
                }

                double seats = double.Parse(Console.ReadLine());
                double soldTickets = 0;

                while (soldTickets < seats)
                {
                    string typeOfTicket = Console.ReadLine();

                    if (typeOfTicket == "End")
                    {
                        break;
                    }

                    soldTickets++;

                    if (typeOfTicket == "student")
                    {
                        ticketsCountByType["student"]++;
                    }
                    else if (typeOfTicket == "standard")
                    {
                        ticketsCountByType["standard"]++;
                    }
                    else
                    {
                        ticketsCountByType["kids"]++;
                    }
                }

                occupiedSeatsByMovie.Add(input, soldTickets / seats * 100);
                totalSoldTickets += soldTickets;
            }


            foreach (var kvp in occupiedSeatsByMovie)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value:f2}% full.");
            }

            Console.WriteLine($"Total tickets: {totalSoldTickets}");

            foreach (var kvp in ticketsCountByType)
            {
                Console.WriteLine($"{kvp.Value/totalSoldTickets*100:f2}% {kvp.Key} tickets.");
            }
        }

    }

}


