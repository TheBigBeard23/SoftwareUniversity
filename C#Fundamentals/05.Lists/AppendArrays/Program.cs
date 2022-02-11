using System;
using System.Collections.Generic;
using System.Linq;

namespace AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> sequences = Console.ReadLine()
                                     .Split('|',StringSplitOptions.RemoveEmptyEntries)
                                     .Reverse()
                                     .ToList();

       
            string sequencesAsString = string.Join(" ", sequences);

            List<string> sequence = sequencesAsString
                                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                    .ToList();

            Console.WriteLine(string.Join(" ",sequence));




        }
    }
}
