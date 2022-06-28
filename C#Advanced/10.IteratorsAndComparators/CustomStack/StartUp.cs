using System;
using System.Collections.Generic;
using System.Linq;

namespace ImplementCustomStack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CustomStack<int> stack = new CustomStack<int>();

            var input = Console.ReadLine();

            while (input != "END")
            {
                if (input.Contains("Pop"))
                {
                    stack.Pop();
                }
                else if (input.Contains("Push"))
                {
                    List<int> list = input
                                 .Split(new string[] { "Push", ", " }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(int.Parse)
                                 .ToList();

                    for (int i = 0; i < list.Count; i++)
                    {
                        stack.Push(list[i]);
                    }
                }

                input = Console.ReadLine();
            }

            Print(stack);
            Print(stack);

        }
        private static void Print(CustomStack<int> stack)
        {
            foreach (var element in stack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
