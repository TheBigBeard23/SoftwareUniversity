using System;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] array = new string[] { "gogo", "pepe", "jose" };

            StackOfStrings stack = new StackOfStrings(array);
            Console.WriteLine(stack.IsEmpty());

            string[] newArr = new string[] { "pesho", "gogi", "koko" };

            Console.WriteLine(string.Join(", ", stack.AddRange(newArr)));

        }
    }
}
