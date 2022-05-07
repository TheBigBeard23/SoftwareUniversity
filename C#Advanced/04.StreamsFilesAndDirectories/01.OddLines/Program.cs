using System;
using System.IO;

namespace _01.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"..\..\..\input.txt";
            string outputFilePath = @"..\..\..\output.txt";


            using (StreamWriter writer = new StreamWriter(inputFilePath))
            {
                string text = Console.ReadLine();

                while (text != "")
                {
                    writer.WriteLine(text);
                    text = Console.ReadLine();
                }
            }

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string text = reader.ReadLine();
                int counter = 1;

                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    while (text != null)
                    {
                        if (counter % 2 == 0)
                        {

                            writer.WriteLine(text);

                        }

                        counter++;
                        text = reader.ReadLine();
                    }
                }
            }

            using (StreamReader reader = new StreamReader(outputFilePath))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }
    }
}
