using System;

namespace GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            switch (type)
            {
                case "int":

                    int firstNumber = int.Parse(Console.ReadLine());
                    int secondNumber = int.Parse(Console.ReadLine());
                    Console.WriteLine(GetMaxInt(firstNumber,secondNumber));

                    break;

                case "string":

                    string firstString = Console.ReadLine();
                    string secondString = Console.ReadLine();
                    Console.WriteLine(GetMaxString(firstString,secondString));

                    break;

                case "char":

                    char firstChar = char.Parse(Console.ReadLine());
                    char secondChar = char.Parse(Console.ReadLine());
                    Console.WriteLine(GetMaxChar(firstChar,secondChar));

                    break;
            }
        }
        static string GetMaxString(string firstString,string secondString)
        {
            int comparison = firstString.CompareTo(secondString);

            if (comparison > 0)
            {
                return firstString;
            }
            else
            {
                return secondString;
            }
        }

        static char GetMaxChar(char firstChar,char secondChar)
        {
            if (firstChar > secondChar)
            {
                return firstChar;
            }
            else
            {
                return secondChar;
            }
        }

        static int GetMaxInt(int firstNumber,int secondNumber)
        {
            if (firstNumber > secondNumber)
            {
                return firstNumber;
            }
            else
            {
                return secondNumber;
            }
        }
    }
}
