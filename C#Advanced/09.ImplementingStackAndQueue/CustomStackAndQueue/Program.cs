using System;

namespace CustomStackAndQueue
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var stack = new CustomStack();

            for (int i = 1; i <= 10; i++)
            {
                stack.Push(i);
            }
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(stack.Pop());
            }
            

        }
    }
}
