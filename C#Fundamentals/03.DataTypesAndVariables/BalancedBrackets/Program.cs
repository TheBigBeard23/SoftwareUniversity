using System;

namespace BalancedBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            int lineCount = int.Parse(Console.ReadLine());
            int brackets = 0;
            

            for (int i = 0; i < lineCount; i++)
            {
                string input = Console.ReadLine();

                if (input == "(")
                {
                    brackets++;
                }
                else if (input == ")")
                {
                    brackets--;
                }
                if (brackets < 0)
                {
                    break;
                }
            }

            if (brackets==0)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}
