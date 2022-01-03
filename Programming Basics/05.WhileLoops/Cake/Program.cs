using System;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {

            int cakeWidth = int.Parse(Console.ReadLine());
            int cakeHeight = int.Parse(Console.ReadLine());
            int cakePieces = cakeHeight * cakeWidth;

            string input = "";
            int takenPieces = 0;
            while ((input = Console.ReadLine())!="STOP")
            {
                takenPieces = int.Parse(input);

                if (cakePieces > takenPieces)
                {
                    cakePieces -= takenPieces;
                }
                else
                {
                    break;
                }


            }
            if (input == "STOP")
            {
                Console.WriteLine($"{cakePieces} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {takenPieces-cakePieces} pieces more.");
            }



        }
    }
}
