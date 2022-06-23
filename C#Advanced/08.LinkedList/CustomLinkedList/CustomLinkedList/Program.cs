using System;

namespace CustomLinkedList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            for (int i = 1; i <= 10; i++)
            {
                list.AddLast(i);
            }

            Console.WriteLine(string.Join(" ", list.ToArray()));

            Console.WriteLine(list.RemoveFirst());
            Console.WriteLine(list.RemoveLast());

            list.ForEach(x => Console.Write($"{x}, "));
            Console.WriteLine();

            while (list.Count > 0)
            {
                Console.WriteLine(list.RemoveFirst());
            }

            list.RemoveFirst();
        }
    }
}
