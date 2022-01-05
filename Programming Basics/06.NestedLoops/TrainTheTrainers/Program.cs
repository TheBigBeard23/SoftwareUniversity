using System;

namespace TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int gradesCount = int.Parse(Console.ReadLine());
            string input = string.Empty;

            double avgGrade = 0.0;
            int presentationsCount = 0;

            while ((input = Console.ReadLine())!="Finish")
            {
                presentationsCount++;
                double currentAvgGrade = 0.0;

                for (int i = 0; i < gradesCount; i++)
                {
                    currentAvgGrade += double.Parse(Console.ReadLine());
                }

                currentAvgGrade = currentAvgGrade / gradesCount;
                avgGrade += currentAvgGrade;
                Console.WriteLine($"{input} - {currentAvgGrade}.");
            }

            avgGrade = avgGrade / presentationsCount;

            Console.WriteLine($"Student's final assessment is {avgGrade}.");



        }
    }
}
