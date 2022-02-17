using System;
using System.Linq;

namespace LadyBugs
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] filed = new int[int.Parse(Console.ReadLine())];

            var indexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < filed.Length; i++)
            {
                if (indexes.Contains(i))
                {
                    filed[i] = 1;
                }
            }

            string input = Console.ReadLine();

            while (input.ToLower()!="end")
            {
                string[] commands = input
                    .Split()
                    .ToArray();

                int index = int.Parse(commands[0]);
                string direction = commands[1];
                int value = int.Parse(commands[2]);

                if(index>=0 && index <= filed.Length - 1)
                {
<<<<<<< HEAD
                   
                    field[index] = 0;

                    if (field[index + value]<=field.Length-1 &&
                       field[index + value] == 1)
                    {
                        index += value;
                    }

                    switch (direction)
=======
                    filed[index] = 0;

                    if(direction=="left" && value < 0)
>>>>>>> 25ce2bf509d2da89d879cd176de27d8f3fa388ce
                    {
                        value *= -1;
                    }
                    else if(direction=="left")
                    {
                        value *= -1;
                    }
                }
                else
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (value >= 0 && index + value < filed.Length)
                {

                    for (int i = index + value; i < filed.Length; i += value)
                    {
                        if (filed[i] != 1)
                        {
                            filed[i] = 1;
                            break;
                        }
                    }
                }
                else if (value < 0 && index + value >= 0)
                {
                    for (int i = index + value; i >= 0; i += value)
                    {
                        if (filed[i] != 1)
                        {
                            filed[i] = 1;
                            break;
                        }
                    }

                }

                input = Console.ReadLine();

            }

            Console.WriteLine(string.Join(" ",filed));
        }
    }
}
            
