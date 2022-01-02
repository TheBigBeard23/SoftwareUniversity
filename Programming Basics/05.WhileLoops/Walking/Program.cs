using System;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            int currentSteps = int.Parse(Console.ReadLine());
            int stepsCount = 0;
            int goalSteps = 10000;
            stepsCount += currentSteps;

            while (stepsCount< goalSteps)
            {
                
                string input = Console.ReadLine();

                if(input == "Going home")
                {
                    stepsCount += int.Parse(Console.ReadLine());
                    break;
                }

                stepsCount += int.Parse(input);

            }
            if (stepsCount >= goalSteps)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{stepsCount- goalSteps} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{goalSteps-stepsCount} more steps to reach goal.");
            }

        }
    }
}
