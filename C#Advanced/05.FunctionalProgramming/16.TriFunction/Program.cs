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

            foreach (var name in names)
            {
                Func<string, bool> ValidateWordDelegate = ValidateWord(n);

                if (ValidateWordDelegate(name))
                {
                    Console.WriteLine(name);
                    break;
                }

            }

        }
        static Func<string, bool> ValidateWord(int n)
        {
            return x => x.ToCharArray()
                         .Select(y => (int)y)
                         .Sum() >= n;
        }
    }
}
