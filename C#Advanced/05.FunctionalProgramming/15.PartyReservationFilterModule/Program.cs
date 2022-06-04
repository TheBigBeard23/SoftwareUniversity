using System;
using System.Collections.Generic;
using System.Linq;

namespace _15.PartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();
            Dictionary<string, List<string>> filterParameters = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "Print")
            {
                string[] data = input.Split(";").ToArray();

                string command = data[0];
                string filter = data[1];
                string parameter = data[2];

                switch (command)
                {
                    case "Remove filter":
                        if (filterParameters.ContainsKey(filter))
                        {
                            filterParameters.Remove(filter);
                        }
                        break;

                    case "Add filter":
                        if (!filterParameters.ContainsKey(filter))
                        {
                            filterParameters[filter] = new List<string>();
                        }
                        filterParameters[filter].Add(parameter);
                        break;
                }

                input = Console.ReadLine();
            }

            foreach (var filter in filterParameters)
            {
                string crnFilter = filter.Key;

                foreach (var parameter in filter.Value)
                {
                    Func<string, bool> GetFilterDelegate = GetFilter(crnFilter, parameter);
                    names = names.Where(GetFilterDelegate).ToList();
                }
            }

            Console.WriteLine(string.Join(" ", names));
        }
        private static Func<string, bool> GetFilter(string filter, string parameter)
        {
            switch (filter)
            {
                case "Starts with":
                    return x => !x.StartsWith(parameter);
                case "Ends with":
                    return x => !x.EndsWith(parameter);
                case "Length":
                    return x => x.Length != int.Parse(parameter);
                case "Contains":
                    return x => !x.Contains(parameter);

            }
            return x => true;
        }
    }
}
