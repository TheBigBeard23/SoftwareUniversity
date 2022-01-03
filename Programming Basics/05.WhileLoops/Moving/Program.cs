using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());

            int placeVolume = width * length * height;
            string input = "";
            int currentBoxVolume = 0;

            while ((input=Console.ReadLine())!="Done")
            {
                currentBoxVolume = int.Parse(input);

                if (placeVolume > currentBoxVolume)
                {
                    placeVolume -= currentBoxVolume;
                }
                else
                {
                    break;
                }


            }

            if (input == "Done")
            {
                Console.WriteLine($"{placeVolume} Cubic meters left.");
            }
            else
            {
                Console.WriteLine($"No more free space! You need {currentBoxVolume-placeVolume} Cubic meters more.");
            }
        }
    }
}
