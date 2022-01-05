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
                ["kid"] = 0

            };

            Dictionary<string, double> occupiedSeatsByMovie = new Dictionary<string, double>();

            

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
                        ticketsCountByType["kid"]++;
                    }
                }

                occupiedSeatsByMovie.Add(input, soldTickets / seats * 100);

            }
            foreach (var kvp in occupiedSeatsByMovie)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}% full.");
            }




        }

    }

}


