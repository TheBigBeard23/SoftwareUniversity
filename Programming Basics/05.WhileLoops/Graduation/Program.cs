using System;

namespace Graduation
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double avgGrade = 0.0;
            int badGrades = 0;
            int level = 0;
            while (level!=12)
            {
                double currentGrade = double.Parse(Console.ReadLine());

                if (currentGrade >= 4)
                {
                    avgGrade += currentGrade;
                    level++;

                }
                else
                {
                    badGrades++;
                    if (badGrades > 1)
                    {
                        Console.WriteLine($"{name} has been excluded at {level} grade");
                        break;
                    }
                }

            }
            if (level == 12)
            {
                Console.WriteLine($"{name} graduated. Average grade: {avgGrade/12:f2}");
            }


           
        }
    }
}
