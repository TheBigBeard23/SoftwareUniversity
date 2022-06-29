using System;

namespace CustomLinkedList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var linkedList = new LinkedList<int>();

            for (int i = 1; i <= 10; i++)
            {
                linkedList.AddLast(i);
            }

            foreach (var value in linkedList)
            {
                Console.WriteLine(value);
            }
        }
    }
}
