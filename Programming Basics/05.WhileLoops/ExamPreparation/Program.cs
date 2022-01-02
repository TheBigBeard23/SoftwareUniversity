using System;

namespace ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int poorGradesCount = int.Parse(Console.ReadLine());

            string lastProblem = "";
            double score = 0.0;
            int problemsCount = 0;
            int currentPoorGrades = 0;

            while (poorGradesCount>currentPoorGrades)
            {
                
                string problem = Console.ReadLine();
                if (problem == "Enough")
                {
                    break;
                }
                int grade = int.Parse(Console.ReadLine());

                

                lastProblem = problem;

                if (grade <= 4)
                {
                    currentPoorGrades++;
                }
                else
                {
                    problemsCount++;
                    score += grade;
                }
            }

            if (poorGradesCount == currentPoorGrades)
            {
                Console.WriteLine($"You need a break, {poorGradesCount} poor grades.");
            }
            else
            {
                Console.WriteLine($"Average score: {score/problemsCount:f2}");
                Console.WriteLine($"Number of problems: {problemsCount}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
        }
    }
}
