using System;
using System.Linq;

namespace ForeignLanguages
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] spanish = new string[] { "argentina", "mexico", "spain" };
            string[] english = new string[] { "england", "usa" };

            string country = Console.ReadLine();

            if (spanish.Contains(country.ToLower()))
            {
                Console.WriteLine("Spanish");
            }
            else if (english.Contains(country.ToLower()))
            {
                Console.WriteLine("English");
            }
            else
            {
                Console.WriteLine("unknown");
            }
        }
    }
}
