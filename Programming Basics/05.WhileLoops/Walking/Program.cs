using System;

namespace Walking
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int stepsCount = 0;
            int goalSteps = 10000;
            

            while (input!= "Going home")
            {

                stepsCount += int.Parse(input);

                if (stepsCount >= goalSteps)
                {
                    break;
                }
                
                input = Console.ReadLine();
            }

            if(input== "Going home")
            {
                input = Console.ReadLine();
                stepsCount += int.Parse(input);
            }
            
            if (stepsCount >= goalSteps)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{stepsCount - goalSteps} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{goalSteps-stepsCount} more steps to reach goal.");
            }

        }
    }
}
