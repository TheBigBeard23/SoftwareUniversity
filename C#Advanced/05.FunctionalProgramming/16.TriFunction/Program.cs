using System;
using System.Linq;

namespace _16.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();


            Func<string, int, bool> isValidWord = (str, num) => str.ToCharArray()
                                                                   .Select(ch => (int)ch)
                                                                   .Sum() >= num;

            Func<string[], int, Func<string, int, bool>, string> firstValidName = (arr, num, func) => arr
                .FirstOrDefault(str => func(str, num));

            string result = firstValidName(names, n, isValidWord);

            Console.WriteLine(result);
        }

    }
}
