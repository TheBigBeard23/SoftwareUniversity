using System;
using System.Collections;
using System.Linq;

namespace _2.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack numbers = new Stack(Console.ReadLine().Split());

            string command = Console.ReadLine();

            while (command.ToLower()!="end")
            {
                string[] data = command.Split().ToArray();

                string operation = data[0].ToLower();

                switch (operation)
                {
                    case "add":
                        Add(numbers, data);
                        break;

                    case "remove":
                        Remove(numbers, data);
                        break;
                }

                command = Console.ReadLine();
            }

            int sum = Sum(numbers);

            Console.WriteLine($"Sum: {sum}");
        }

        static int Sum(Stack numbers)
        {
            int sum = 0;
            while (numbers.Count>0)
            {
                sum += int.Parse(numbers.Pop().ToString());
            }
            return sum;
        }

        static void Remove(Stack numbers, string[] data)
        {
            int count = int.Parse(data[1]);

            if (count <= numbers.Count)
            {
                for (int i = 0; i < count; i++)
                {
                    numbers.Pop();
                }
            }
        }

        static void Add(Stack numbers, string[] data)
        {
            string firstNumber = data[1];
            string secondNumber = data[2];

            numbers.Push(firstNumber);
            numbers.Push(secondNumber);

        }
    }
}
