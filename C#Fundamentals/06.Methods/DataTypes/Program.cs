using System;

namespace DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();

            switch (dataType)
            {

                case "int":

                    int numberInt = int.Parse(Console.ReadLine());
                    Console.WriteLine(CalculateInt(numberInt));

                    break;

                case "real":

                    double numberDouble = double.Parse(Console.ReadLine());
                    Console.WriteLine($"{CalculateDouble(numberDouble):f2}");

                    break;

                case "string":

                    string word = Console.ReadLine();
                    Console.WriteLine(ModificateString(word));

                    break;
            }
        }
        static int CalculateInt(int number)
        {
            return number * 2;
        }
        static double CalculateDouble(double number)
        {
            return number * 1.50;
        }
        static string ModificateString(string word)
        {
            return $"${word}$";
        }
    }
}
