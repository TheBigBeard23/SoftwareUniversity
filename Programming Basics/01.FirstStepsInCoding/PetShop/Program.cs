using System;

namespace PetShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int dogCount = int.Parse(Console.ReadLine());
            int animalCount = int.Parse(Console.ReadLine());
            Console.WriteLine($"{dogCount*2.50+animalCount*4} lv.");
        }
    }
}
