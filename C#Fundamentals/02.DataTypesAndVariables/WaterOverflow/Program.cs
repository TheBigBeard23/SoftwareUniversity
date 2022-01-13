using System;

namespace WaterOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int tankQuanity = 0;

            for (int i = 0; i < count; i++)
            {
                int quanity = int.Parse(Console.ReadLine());

                if (tankQuanity + quanity <= 255)
                {
                    tankQuanity += quanity;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                }
            }

            Console.WriteLine(tankQuanity);
        }
    }
}
