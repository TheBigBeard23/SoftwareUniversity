using System;

namespace PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double amount = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());

            double sumLightsabers = (studentsCount + Math.Ceiling(studentsCount * 0.1)) * lightsaberPrice;
            double sumBelts = (studentsCount - studentsCount / 6) * beltPrice;
            double sumRobes = studentsCount * robePrice;

            double totalSum = sumLightsabers + sumBelts + sumRobes;

            if (totalSum < amount)
            {
                Console.WriteLine($"The money is enough - it would cost {totalSum:f2}lv.");
            }
            else
            {
                Console.WriteLine($" John will need {totalSum - amount:f2}lv more.");
            }
        }
    }
}