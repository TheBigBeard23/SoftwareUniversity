using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _4.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Queue<string> symbols = new Queue<string>();

            for (int i = 0; i < input.Length; i++)
            {
                symbols.Enqueue(input[i].ToString());
            }

            while (symbols.Count > 0)
            {
                FindExpression(symbols);
            }
           
        }

        private static string FindExpression(Queue<string> symbols)
        {
            string crnSymbol = symbols.Dequeue();

            string expression = string.Empty;

            if (crnSymbol == "(")
            {
                expression += crnSymbol;

                while (crnSymbol != ")")
                {
                    crnSymbol = symbols.Peek();

                    if (crnSymbol == "(")
                    {
                        expression += FindExpression(symbols);
                    }
                    else
                    {
                        expression += crnSymbol;
                        symbols.Dequeue();
                    }
                    
                }
            }

            if (expression != "")
            {
                Console.WriteLine(expression);
            }

            return expression;

        }

    }
}
