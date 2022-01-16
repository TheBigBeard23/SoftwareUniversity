using System;

namespace Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int snowballSnow = 0;
            int snowballTime = 0;
            int snowballQuality = 0;
            int snowballValue = 0;
            for (int i = 0; i < count; i++)
            {
                int currentSnowballSnow = int.Parse(Console.ReadLine());
                int currentSnowballTime = int.Parse(Console.ReadLine());
                int currentSnowballQuality = int.Parse(Console.ReadLine());
                int currentSnowballValue = (int)Math.Pow((currentSnowballSnow / currentSnowballTime),currentSnowballQuality);

                if (currentSnowballValue > snowballValue)
                {
                    snowballSnow = currentSnowballSnow;
                    snowballTime = currentSnowballTime;
                    snowballQuality = currentSnowballQuality;
                    snowballValue = currentSnowballValue;
                }

            }

            Console.WriteLine($"{snowballSnow} : {snowballTime} = {snowballValue} ({snowballQuality})");
        }
    }
}
