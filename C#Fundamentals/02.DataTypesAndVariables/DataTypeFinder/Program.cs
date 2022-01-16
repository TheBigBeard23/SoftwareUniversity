using System;

namespace DataTypeFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            while ((input=Console.ReadLine())!="END")
            {
                int number;

                if(!int.TryParse(input,out number))
                {
                    if (input.Length == 1)
                    {
                        Console.WriteLine($"{input} is character type");
                    }
                    else if(input.ToLower()=="true" || input.ToLower() == "false")
                    {
                        Console.WriteLine($"{input} is boolean type");
                    }
                    else
                    {
                        Console.WriteLine($"{input} is string type");
                    }                
                }

                else if (int.TryParse(input, out number))
                {
                    Console.WriteLine($"{input} is integer type");
                }
                else
                {
                    Console.WriteLine($"{input} is floating point type");
                }
            }
        }
    }
}
