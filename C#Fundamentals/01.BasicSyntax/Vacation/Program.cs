using System;

namespace Vacation
{
    class Program
    {
        static void Main(string[] args)
        {
            double groupMember = double.Parse(Console.ReadLine());
            string typeOfGroup = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double sum = 0;

            switch (dayOfWeek)
            {
                case ("Friday"):

                    if (typeOfGroup == "Students")
                    {
                        sum = groupMember * 8.45;
                    }
                    else if (typeOfGroup == "Business")
                    {
                        sum = groupMember * 10.90;
                    }
                    else if (typeOfGroup == "Regular")
                    {
                        sum = groupMember * 15;
                    }


                    break;

                case ("Saturday"):
                    if (typeOfGroup == "Students")
                    {
                        sum = groupMember * 9.80;
                    }
                    else if (typeOfGroup == "Business")
                    {
                        sum = groupMember * 15.60;
                    }
                    else if (typeOfGroup == "Regular")
                    {
                        sum = groupMember * 20;
                    }

                    break;

                case ("Sunday"):
                    if (typeOfGroup == "Students")
                    {
                        sum = groupMember * 10.46;
                    }
                    else if (typeOfGroup == "Business")
                    {
                        sum = groupMember * 16;
                    }
                    else if (typeOfGroup == "Regular")
                    {
                        sum = groupMember * 22.50;
                    }

                    break;


            }
            if (typeOfGroup == "Students" && groupMember >= 30)
            {
                sum = sum - (sum * 0.15);
            }
            else if (typeOfGroup == "Business" && groupMember >= 100)
            {
                sum = sum - ((sum / groupMember) * 10);
            }
            else if (typeOfGroup == "Regular" && groupMember >= 10 && groupMember <= 20)
            {
                sum = sum - (sum * 0.05);
            }

            Console.WriteLine("Total price: " + "{0:F2}", sum);
        }
    }
}
