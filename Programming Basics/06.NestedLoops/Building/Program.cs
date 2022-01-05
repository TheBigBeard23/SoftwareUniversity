using System;

namespace Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int floors = int.Parse(Console.ReadLine());
            int roomsOnFloor = int.Parse(Console.ReadLine());
            string typeOfRooms = "";
            for (int i = floors; i >= 1; i--)
            {
                if (i == floors)
                {
                    typeOfRooms = "L";
                }
                else if (i % 2 == 0)
                {

                    typeOfRooms = "O";
                }
                else
                {
                    typeOfRooms = "A";
                }

                for (int k = 0; k < roomsOnFloor; k++)
                {
                    Console.Write($"{typeOfRooms}{i}{k} ");
                }
                Console.WriteLine();
            }

        }
    }
}
